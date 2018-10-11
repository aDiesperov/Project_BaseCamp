using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstateAgency.Data;
using RealEstateAgency.Models;

namespace RealEstateAgency.Areas.Identity.Pages.Account.Manage
{
    public partial class ApplicationsForAgentModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly UnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;

        public ApplicationsForAgentModel(
            UserManager<IdentityUser> userManager,
            UnitOfWork unitOfWork,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }
        
        [TempData]
        public string StatusMessage { get; set; }
        public IEnumerable<ApplicationForAgent> Applications { get; set; }

        public IActionResult OnGet()
        {
            if (!User.IsInRole("Administrator") && !User.IsInRole("Moderator"))
                return Forbid();

            Applications = _unitOfWork.ApplicationForAgentRepository.FindWithUser(app => app.Active == true);            

            return Page();
        }

        public async Task<IActionResult> OnPostConfirmAsync(int id)
        {
            if (!User.IsInRole("Administrator") && !User.IsInRole("Moderator"))
                return Forbid();

            ApplicationForAgent applicationForAgent = await _unitOfWork.ApplicationForAgentRepository.GetByIdWithUserAsync(id);

            if (applicationForAgent != null && applicationForAgent.Active)
            {
                Agent agent = new Agent()
                {
                    Name = applicationForAgent.Name,
                    Description = applicationForAgent.Description,
                    Rating = 0,
                    User = applicationForAgent.User,
                    Active = true,
                    DateChangeActive = DateTime.Now
                };

                await _unitOfWork.AgentRepository.CreateAsync(agent);
                applicationForAgent.Active = false;
                await _unitOfWork.ApplicationForAgentRepository.UpdateAsync(applicationForAgent);

                await _userManager.AddToRoleAsync(applicationForAgent.User, "Agent");

                StatusMessage = "Conformed!";
            }
            else
            {
                StatusMessage = "Error: current row doesn't exist !";
            }
            
            return RedirectToPage();            
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            if (!User.IsInRole("Administrator") && !User.IsInRole("Moderator"))
                return Forbid();

            ApplicationForAgent applicationForAgent = await _unitOfWork.ApplicationForAgentRepository.GetByIdAsync(id);
            if(applicationForAgent != null)
            {
                await _unitOfWork.ApplicationForAgentRepository.DeleteAsync(applicationForAgent);
                StatusMessage = "Deleted!";
            }
            else
            {
                StatusMessage = "Error: current row doesn't exist!";
            }
            
            return RedirectToPage();
        }
    }
}

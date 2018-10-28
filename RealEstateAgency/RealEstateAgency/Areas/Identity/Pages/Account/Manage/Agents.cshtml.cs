using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstateAgency.Data;
using RealEstateAgency.Models;

namespace RealEstateAgency.Areas.Identity.Pages.Account.Manage
{
    public partial class AgentsModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public AgentsModel(
            UnitOfWork unitOfWork,
            UserManager<IdentityUser> userManager,
            IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _emailSender = emailSender;
        }
        
        [TempData]
        public string StatusMessage { get; set; }
        public IEnumerable<Agent> Agents { get; set; }

        public IActionResult OnGet()
        {
            if (!User.IsInRole("Administrator") && !User.IsInRole("Moderator"))
                return Forbid();

            Agents = _unitOfWork.AgentRepository.GetAll();
            var user = Agents.First().User;

            return Page();
        }

        public async Task<IActionResult> OnPostOnOffAsync(int id)
        {
            if (!User.IsInRole("Administrator") && !User.IsInRole("Moderator"))
                return Forbid();

            Agent agent = await _unitOfWork.AgentRepository.GetByIdAsync(id);

            if (agent != null)
            {
                agent.Active = !agent.Active;
                await _unitOfWork.AgentRepository.UpdateAsync(agent);
                
                if (agent.Active) await _userManager.AddToRoleAsync(agent.User, "Agent");
                else await _userManager.RemoveFromRoleAsync(agent.User, "Agent");

                StatusMessage = agent.Active ? "Agent has been enabled!" : "Agent has been disabled";
            }
            else
            {
                StatusMessage = "Error: agent doesn't exist!";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            if (!User.IsInRole("Administrator") && !User.IsInRole("Moderator"))
                return Forbid();

            Agent agent = await _unitOfWork.AgentRepository.GetByIdAsync(id);

            if (agent != null)
            {
                if (agent.Active) await _userManager.RemoveFromRoleAsync(agent.User, "Agent");

                await _unitOfWork.AgentRepository.DeleteAsync(agent);
                StatusMessage = "Agent has been deleted!";
            }
            else
            {
                StatusMessage = "Error: agent doesn't exist!";
            }

            return RedirectToPage();
        }
    }
}

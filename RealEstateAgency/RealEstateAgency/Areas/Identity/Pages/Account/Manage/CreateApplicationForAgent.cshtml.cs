using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstateAgency.Data;
using RealEstateAgency.Models;

namespace RealEstateAgency.Areas.Identity.Pages.Account.Manage
{
    public partial class CreateApplicationForAgentModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly UnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;

        public CreateApplicationForAgentModel(
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

        [BindProperty]
        public ApplicationModel Application { get; set; }

        public class ApplicationModel
        {
            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
            public string Name { get; set; }
            
            [MinLength(100, ErrorMessage = "The {0} must be at least {1} characters long.")]
            public string Description { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if(await _unitOfWork.ApplicationForAgentRepository.GetByUserAsync(await _userManager.GetUserAsync(User)) != null)
                return Forbid();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _unitOfWork.ApplicationForAgentRepository.GetByUserAsync(await _userManager.GetUserAsync(User)) != null)
                return Forbid();

            if (ModelState.IsValid)
            {

                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }

                ApplicationForAgent applicationForAgent = new ApplicationForAgent()
                {
                    Name = Application.Name,
                    Description = Application.Description,
                    Active = true,
                    User = user,
                    Date = DateTime.Now
                };

                await _unitOfWork.ApplicationForAgentRepository.CreateAsync(applicationForAgent);

                StatusMessage = "The application has been sent!";
                return RedirectToPage("./Index");
            }
            return Page();
        }
        
    }
}

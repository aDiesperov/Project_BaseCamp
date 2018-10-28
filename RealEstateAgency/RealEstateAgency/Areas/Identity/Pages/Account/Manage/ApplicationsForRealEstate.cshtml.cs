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
    public partial class ApplicationsForRealEstateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly UnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;

        public ApplicationsForRealEstateModel(
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
        public IEnumerable<ApplicationForRealEstate> Applications { get; set; }

        public IActionResult OnGet()
        {
            if (!User.IsInRole("Administrator") && !User.IsInRole("Moderator") && !User.IsInRole("Agent"))
                return Forbid();

            Applications = _unitOfWork.ApplicationForRealEstateRepository.GetAllActive();            

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            if (!User.IsInRole("Administrator") && !User.IsInRole("Moderator"))
                return Forbid();

            ApplicationForRealEstate application = await _unitOfWork.ApplicationForRealEstateRepository.GetByIdAsync(id);
            if(application != null)
            {
                await _unitOfWork.ApplicationForRealEstateRepository.DeleteAsync(application);
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

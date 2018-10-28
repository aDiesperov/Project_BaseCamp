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
    public partial class MyApplicationForRealEstateModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public MyApplicationForRealEstateModel(
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
        public IEnumerable<ApplicationForRealEstate> Applications { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            Applications = _unitOfWork.ApplicationForRealEstateRepository.GetAllByUser(await _userManager.GetUserAsync(User));

            return Page();
        }

        public async Task<IActionResult> OnPostOnOffAsync(int id)
        {
            ApplicationForRealEstate application = await _unitOfWork.ApplicationForRealEstateRepository.GetByIdAsync(id);
            
            if (application != null && application.Author == await _userManager.GetUserAsync(User))
            {
                application.Active = !application.Active;
                await _unitOfWork.ApplicationForRealEstateRepository.UpdateAsync(application);

                StatusMessage = application.Active ? "Application has been enabled!" : "Application has been disabled";
            }
            else
            {
                StatusMessage = "Error: application doesn't exist!";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            ApplicationForRealEstate application = await _unitOfWork.ApplicationForRealEstateRepository.GetByIdAsync(id);

            if (application.Author == await _userManager.GetUserAsync(User))
            {
                await _unitOfWork.ApplicationForRealEstateRepository.DeleteAsync(application);

                StatusMessage = "Application deleted!";
            }
            else
            {
                StatusMessage = "Error: application doesn't exist!";
            }

            return RedirectToPage();
        }
    }
}

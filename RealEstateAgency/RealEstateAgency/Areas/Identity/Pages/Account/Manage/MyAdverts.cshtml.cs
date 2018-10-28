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
    public partial class MyAdvertsModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public MyAdvertsModel(
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
        public IEnumerable<Advert> Adverts { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.IsInRole("Agent"))
                return Forbid();
            
            Adverts = _unitOfWork.AdvertRepository.GetAllByUser(await _userManager.GetUserAsync(User));

            return Page();
        }

        public async Task<IActionResult> OnPostOnOffAsync(int id)
        {
            if (!User.IsInRole("Agent"))
                return Forbid();

            Advert advert = await _unitOfWork.AdvertRepository.GetByIdAsync(id);

            if (advert != null && 
                advert.Author.User.Equals(await _userManager.GetUserAsync(User)) && 
                (((int)advert.StatusActive & 10) == (int)advert.StatusActive))
            {
                advert.StatusActive = (advert.StatusActive == TypeStatusAdvert.resolved) ? TypeStatusAdvert.notRelevant : TypeStatusAdvert.resolved;
                await _unitOfWork.AdvertRepository.UpdateAsync(advert);

                StatusMessage = advert.StatusActive == TypeStatusAdvert.resolved ? "Advert has been enabled!" : "Advert has been disabled";
            }
            else
            {
                StatusMessage = "Error: advert doesn't exist!";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            if (!User.IsInRole("Agent"))
                return Forbid();

            Advert advert = await _unitOfWork.AdvertRepository.GetByIdAsync(id);

            if (advert != null && advert.Author.User.Equals(await _userManager.GetUserAsync(User)))
            {
                await _unitOfWork.AdvertRepository.DeleteAsync(advert);
                StatusMessage = "Advert has been deleted!";
            }
            else
            {
                StatusMessage = "Error: advert doesn't exist!";
            }

            return RedirectToPage();
        }
    }
}

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
    public partial class AdvertsModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public AdvertsModel(
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

        public IActionResult OnGet()
        {
            if (!User.IsInRole("Administrator") && !User.IsInRole("Moderator"))
                return Forbid();

            Adverts = _unitOfWork.AdvertRepository.GetAllWithTypeAndUser();

            return Page();
        }

        public async Task<IActionResult> OnPostResolveAsync(int id)
        {
            if (!User.IsInRole("Administrator") && !User.IsInRole("Moderator"))
                return Forbid();

            Advert advert = await _unitOfWork.AdvertRepository.GetWithUserByIdAsync(id);            

            if (advert != null)
            {
                var user = advert.Author.User;

                if ((user.Equals(await _userManager.GetUserAsync(User)) ||
                (!await _userManager.IsInRoleAsync(user, "Administrator") &&
                !await _userManager.IsInRoleAsync(user, "Moderator"))) &&
                (((int)advert.StatusActive & 5) == (int)advert.StatusActive))
                {
                    advert.StatusActive = TypeStatusAdvert.resolved;
                    await _unitOfWork.AdvertRepository.UpdateAsync(advert);

                    StatusMessage = "Advert has been enabled!";
                }
                else
                {
                    StatusMessage = "Error: forbidden!";
                }
            }
            else
            {
                StatusMessage = "Error: advert doesn't exist!";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRejectAsync(int id)
        {
            if (!User.IsInRole("Administrator") && !User.IsInRole("Moderator"))
                return Forbid();

            Advert advert = await _unitOfWork.AdvertRepository.GetWithUserByIdAsync(id);
            

            if (advert != null)
            {
                var user = advert.Author.User;

                if ((user.Equals(await _userManager.GetUserAsync(User)) ||
                (!await _userManager.IsInRoleAsync(user, "Administrator") &&
                !await _userManager.IsInRoleAsync(user, "Moderator"))) &&
                (((int)advert.StatusActive & 3) == (int)advert.StatusActive))
                {
                    advert.StatusActive = TypeStatusAdvert.rejected;
                    await _unitOfWork.AdvertRepository.UpdateAsync(advert);
                    StatusMessage = "Advert has been disabled!";
                }
                else
                {
                    StatusMessage = "Error: forbidden!";
                }
            }
            else
            {
                StatusMessage = "Error: advert doesn't exist!";
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            if (!User.IsInRole("Administrator") && !User.IsInRole("Moderator"))
                return Forbid();

            Advert advert = await _unitOfWork.AdvertRepository.GetWithUserByIdAsync(id);            

            if (advert != null)
            {
                var user = advert.Author.User;

                if ((user.Equals(await _userManager.GetUserAsync(User)) ||
                (!await _userManager.IsInRoleAsync(user, "Administrator") &&
                !await _userManager.IsInRoleAsync(user, "Moderator"))))
                {
                    await _unitOfWork.AdvertRepository.DeleteAsync(advert);
                    StatusMessage = "Advert has been deleted!";
                }
                else
                {
                    StatusMessage = "Error: forbidden!";
                }
            }
            else
            {
                StatusMessage = "Error: advert doesn't exist!";
            }

            return RedirectToPage();
        }
    }
}

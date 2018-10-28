using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Data;
using RealEstateAgency.Models;
using RealEstateAgency.ViewModels;

namespace RealEstateAgency.Controllers
{
    public class OfferController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public OfferController(UnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int id)
        {
            OfferRealEstate offer = await _unitOfWork.OfferRealEstateRepository.GetByIdAsync(id);
            if (offer != null && offer.ApplicationForRealEstate.Author == await _userManager.GetUserAsync(User))
            {
                if (offer.TypeStatusOffer == TypeStatusOffer.waiting)
                {
                    if (offer.Advert.StatusActive != TypeStatusAdvert.resolved ||
                    !offer.ApplicationForRealEstate.Active)
                    {
                        offer.TypeStatusOffer = TypeStatusOffer.off;
                        await _unitOfWork.OfferRealEstateRepository.UpdateAsync(offer);
                    }
                }

                return View(offer);
            }
            return Redirect("/Chat");
        }

        public async Task<IActionResult> Resolve(int id)
        {
            await RejectResolveAsync(id, true);
            return RedirectToAction("Index", new { id });
        }

        public async Task<IActionResult> Reject(int id)
        {
            await RejectResolveAsync(id, false);
            return RedirectToAction("Index", new { id });
        }

        private async Task RejectResolveAsync(int id, bool resolve)
        {
            OfferRealEstate offer = await _unitOfWork.OfferRealEstateRepository.GetByIdAsync(id);
            if (offer != null &&
                offer.TypeStatusOffer == TypeStatusOffer.waiting &&
                offer.Advert.StatusActive == TypeStatusAdvert.resolved &&
                offer.ApplicationForRealEstate.Active &&
                offer.ApplicationForRealEstate.Author == await _userManager.GetUserAsync(User))
            {
                if (resolve)
                {
                    offer.Advert.StatusActive = TypeStatusAdvert.notRelevant;
                    offer.ApplicationForRealEstate.Active = false;
                    offer.TypeStatusOffer = TypeStatusOffer.resolved;
                }
                else
                {
                    offer.TypeStatusOffer = TypeStatusOffer.rejected;
                }
                await _unitOfWork.OfferRealEstateRepository.UpdateAsync(offer);
            }
        }
    }
}
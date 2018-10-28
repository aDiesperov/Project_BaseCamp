using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using RealEstateAgency.Data;
using RealEstateAgency.Hubs;
using RealEstateAgency.Models;

namespace RealEstateAgency.Areas.Identity.Pages.Account.Manage
{
    public class OfferRealEstateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly UnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;

        public OfferRealEstateModel(
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

        public ApplicationForRealEstate Application { get; set; }
        public IEnumerable<Advert> Adverts { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (!User.IsInRole("Agent"))
                return Forbid();

            Application = await _unitOfWork.ApplicationForRealEstateRepository.GetByIdAsync(id);
            if (Application == null || !Application.Active)
                return NotFound();

            Adverts = _unitOfWork.AdvertRepository.GetAllResolveByUser(await _userManager.GetUserAsync(User));
            if (Adverts.Count() == 0)
            {
                StatusMessage = "Error: you have not adverts!";
                return RedirectToPage("./ApplicationsForRealEstate");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int AdvertId, int ApplicationForRealEstateId)
        {
            if (!User.IsInRole("Agent"))
                return Forbid();

            Advert advert = await _unitOfWork.AdvertRepository.GetByIdAsync(AdvertId);
            ApplicationForRealEstate application = await _unitOfWork.ApplicationForRealEstateRepository.GetByIdAsync(ApplicationForRealEstateId);

            if (advert != null && application != null &&
                advert.StatusActive == TypeStatusAdvert.resolved &&
                application.Active) {
                var user = await _userManager.GetUserAsync(User);
                if (advert.Author.User.Equals(user)) {

                    OfferRealEstate offer = new OfferRealEstate()
                    {
                        Advert = advert,
                        ApplicationForRealEstate = application,
                        TypeStatusOffer = TypeStatusOffer.waiting
                    };

                    await _unitOfWork.OfferRealEstateRepository.CreateAsync(offer);

                    Message msg = new Message()
                    {
                        FromUser = user,
                        ToUser = application.Author,
                        Date = DateTime.Now,
                        MessageText = ""
                    };
                    await _unitOfWork.MessageRepository.CreateAsync(msg);

                    msg.MessageText = "<div class=\"card\">" +
                                        "<h5 class=\"card-header\">Offer</h5>" +
                                        "<div class=\"card-body\">" +
                                            $"<h5 class=\"card-title\">{advert.Name}</h5>" +
                                            $"<p class=\"card-text\">{advert.Description}</p>" +
                                        "</div><ul class=\"list-group list-group-flush\">" +
                                            $"<li class=\"list-group-item\">Total area: {advert.TotalArea}</li>" +
                                            $"<li class=\"list-group-item\">Price: {advert.Price}</li>" +
                                        "</ul><div style=\"justify-content: center; display: flex;\" class=\"card-body\">" +
                                            $"<a href = \"{Url.Action("Index", "Offer", new { id = offer.OfferRealEstateId})}\" class=\"btn btn-info\">Review</a>" +
                                        "</div></div>";

                    await _unitOfWork.MessageRepository.UpdateAsync(msg);

                    IHubContext<ChatHub>  chat = (IHubContext < ChatHub > )HttpContext.RequestServices.GetService(typeof(IHubContext<ChatHub>));
                    await chat.Clients.User(msg.ToUser.Id).SendAsync("ReceiveMessage", msg);

                    StatusMessage = "Offer has been sent!";
                }
                else
                {
                    StatusMessage = "Error: It's not your advert!";
                }
            }
            else
            {
                StatusMessage = "Error: Advert or application isn't exist!";
            }
            return RedirectToPage("./ApplicationsForRealEstate");
        }
    }
}
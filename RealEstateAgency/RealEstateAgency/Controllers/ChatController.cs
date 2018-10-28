using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Data;
using RealEstateAgency.Models;

namespace RealEstateAgency.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private UnitOfWork _unitOfWork;
        private UserManager<IdentityUser> _userManager;

        public ChatController(UnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Message> messages = _unitOfWork.MessageRepository.GetAllChatsByUser(await _userManager.GetUserAsync(User));

            return View(messages);
        }
    }
}
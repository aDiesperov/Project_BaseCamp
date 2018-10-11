using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using RealEstateAgency.Data;
using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Hubs
{
    public class ChatHub : Hub
    {
        private UnitOfWork _unitOfWork;
        private UserManager<IdentityUser> _userManager;

        public ChatHub(UnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task SendMessage(string message, string toUser)
        {
            Message msg = new Message() {
                MessageText = message,
                Date = DateTime.Now,
                ToUser = await _userManager.FindByNameAsync(toUser),
                FromUser = await _userManager.GetUserAsync(Context.User)
            };

            await _unitOfWork.MessageRepository.CreateAsync(msg);

            await Clients.User(msg.ToUser.Id).SendAsync("ReceiveMessage", message);
            if (msg.ToUser.UserName != msg.FromUser.UserName)
            {
                await Clients.Caller.SendAsync("ReceiveMessage", message);
            }

        }
    }
}

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
        public async Task<Message> SendMessage(string message, string toUser)
        {
            IdentityUser ToUser = await _userManager.FindByNameAsync(toUser);
            if (ToUser == null) throw new ArgumentException("User doesn't exist!");
            IdentityUser FromUser = await _userManager.GetUserAsync(Context.User);
            if (FromUser == null) throw new ArgumentException("User doesn't exist!");

            Message msg = new Message() {
                MessageText = message,
                Date = DateTime.Now,
                ToUser = ToUser,
                FromUser = FromUser
            };

            await _unitOfWork.MessageRepository.CreateAsync(msg);

            if(msg.ToUser != msg.FromUser)
                await Clients.User(msg.ToUser.Id).SendAsync("ReceiveMessage", msg);
            return msg;
        }

        public async Task<IEnumerable<Message>> GetAllChatByUser(string name)
        {
            IdentityUser toUser = await _userManager.FindByNameAsync(name);
            if (toUser == null) return null;
            IdentityUser user = await _userManager.GetUserAsync(Context.User);
            if (user == null) return null;

            return _unitOfWork.MessageRepository.GetAllChatByUsers(toUser, user);
        }

        public async Task<bool> UserIsExist(string user)
        {
            if (await _userManager.FindByNameAsync(user) == null) return false;
            return true;
        }
    }
}

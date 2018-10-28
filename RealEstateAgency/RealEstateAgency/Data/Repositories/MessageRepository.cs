using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Data.Interfaces;
using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Data.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Message> GetAllChatsByUser(IdentityUser user)
        {
            return GetAll().Where(msg => msg.FromUser == user || msg.ToUser == user)
                                .GroupBy(msg => msg.ToUser.UserName == user.UserName ? msg.FromUser.UserName : msg.ToUser.UserName)
                                .Select(groupMsg => groupMsg.OrderBy(msg => msg.MessageId).Last())
                                .AsEnumerable()
                                .OrderByDescending(msg => msg.MessageId);
        }

        public IEnumerable<Message> GetAllChatByUsers(IdentityUser toUser, IdentityUser user)
        {
            return GetAll().Where(msg => (msg.FromUser == user && msg.ToUser == toUser) ||
                                        (msg.FromUser == toUser && msg.ToUser == user));
        }
    }
}

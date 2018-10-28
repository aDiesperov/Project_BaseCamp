﻿using Microsoft.AspNetCore.Identity;
using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Data.Interfaces
{
    interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> GetAllChatsByUser(IdentityUser user);
        IEnumerable<Message> GetAllChatByUsers(IdentityUser toUser, IdentityUser user);
    }
}

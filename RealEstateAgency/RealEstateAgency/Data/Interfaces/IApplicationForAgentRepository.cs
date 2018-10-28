using Microsoft.AspNetCore.Identity;
using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Data.Interfaces
{
    interface IApplicationForAgentRepository : IRepository<ApplicationForAgent>
    {
        Task<ApplicationForAgent> GetByUserAsync(IdentityUser user);
    }
}

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
        ApplicationForAgent GetByUser(IdentityUser user);
        Task<ApplicationForAgent> GetByIdWithUserAsync(int id);
        IEnumerable<ApplicationForAgent> FindWithUser(Func<ApplicationForAgent, bool> predicate);
    }
}

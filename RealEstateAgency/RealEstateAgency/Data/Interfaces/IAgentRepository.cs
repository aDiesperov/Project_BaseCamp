using Microsoft.AspNetCore.Identity;
using RealEstateAgency.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Data.Interfaces
{
    interface IAgentRepository : IRepository<Agent>
    {
        Task<Agent> GetByUserAsync(IdentityUser user);
    }
}

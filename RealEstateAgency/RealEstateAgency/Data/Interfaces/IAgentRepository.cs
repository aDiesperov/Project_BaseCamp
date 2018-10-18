using Microsoft.AspNetCore.Identity;
using RealEstateAgency.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Data.Interfaces
{
    interface IAgentRepository : IRepository<Agent>
    {
        Task<Agent> GetByUserAsync(IdentityUser user);
        IEnumerable<Agent> GetAllWithUser();
        Task<Agent> GetByIdWithUserAsync(int id);
    }
}

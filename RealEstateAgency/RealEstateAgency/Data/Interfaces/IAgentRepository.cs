using Microsoft.AspNetCore.Identity;
using RealEstateAgency.Models;
using System.Collections.Generic;

namespace RealEstateAgency.Data.Interfaces
{
    interface IAgentRepository : IRepository<Agent>
    {
        Agent GetByUser(IdentityUser user);
        IEnumerable<Agent> GetAllWithUser();
    }
}

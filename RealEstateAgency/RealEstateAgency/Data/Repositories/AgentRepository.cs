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
    public class AgentRepository : Repository<Agent>, IAgentRepository
    {
        public AgentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Agent> GetByUserAsync(IdentityUser user)
        {
            return await base.GetAll().SingleOrDefaultAsync(agent => agent.User == user);
        }
    }
}

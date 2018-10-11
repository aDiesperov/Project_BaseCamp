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

        public Agent GetByUser(IdentityUser user)
        {
            return Find(agent => agent.User == user).SingleOrDefault();
        }

        public IEnumerable<Agent> GetAllWithUser()
        {
            return GetAll().Include(agent => agent.User);
        }

        public async Task<Agent> GetByIdWithUserAsync(int id)
        {
            return await GetAll().Include(agent => agent.User).Where(agent => agent.AgentId == id).SingleOrDefaultAsync();
        }
    }
}

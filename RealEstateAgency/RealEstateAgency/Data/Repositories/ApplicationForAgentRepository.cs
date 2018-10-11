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
    public class ApplicationForAgentRepository : Repository<ApplicationForAgent>, IApplicationForAgentRepository
    {
        public ApplicationForAgentRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationForAgent GetByUser(IdentityUser user)
        {
            return Find(app => app.User == user).SingleOrDefault();
        }

        public async Task<ApplicationForAgent> GetByIdWithUserAsync(int id)
        {
            return await GetAll().Include(app => app.User).SingleOrDefaultAsync(app => app.ApplicationForAgentId == id);
            
        }

        public IEnumerable<ApplicationForAgent> FindWithUser(Func<ApplicationForAgent, bool> predicate)
        {
            return GetAll().Include(app => app.User).Where(predicate);
        }
    }
}

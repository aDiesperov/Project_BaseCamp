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

        public async Task<ApplicationForAgent> GetByUserAsync(IdentityUser user)
        {
            return await GetAll().SingleOrDefaultAsync(app => app.User == user);
        }
    }
}

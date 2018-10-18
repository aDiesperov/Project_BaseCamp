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
    public class ApplicationForRealEstateRepository : Repository<ApplicationForRealEstate>, IApplicationForRealEstateRepository 
    {
        public ApplicationForRealEstateRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<ApplicationForRealEstate> GetMyApplication(IdentityUser User)
        {
            return GetAll().Where(app => app.Author == User);
        }

        public async Task<ApplicationForRealEstate> GetByIdWithUserAsync(int id)
        {
            return await GetAll().Include(app => app.Author).SingleOrDefaultAsync(app => app.ApplicationForRealEstateId == id);
        }
    }
}

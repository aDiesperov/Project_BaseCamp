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
    public class AdvertRepository : Repository<Advert>, IAdvertRepository
    {
        public AdvertRepository(ApplicationDbContext context) : base(context) { }

        public IQueryable<Advert> GetAllWithType()
        {
            return GetAll().Include(advert => advert.TypeRealEstate);
        }

        public IQueryable<Advert> GetAllWithTypeByAgent(IdentityUser user)
        {
            return GetAllWithType().Where(advert => advert.Author.User.Equals(user));
        }

        public Task<Advert> GetWithUserByIdAsync(int id)
        {
            return GetAll().Include(advert => advert.Author).ThenInclude(agent => agent.User).SingleOrDefaultAsync(advert => advert.AdvertId == id);
        }

        public IQueryable<Advert> GetAllResolveWithType()
        {
            return GetAllWithType().Where(advert => advert.StatusActive == TypeStatusAdvert.resolved);
        }

        public IQueryable<Advert> GetAllWithTypeAndUser()
        {
            return GetAllWithType().Include(advert => advert.Author);
        }
    }
}

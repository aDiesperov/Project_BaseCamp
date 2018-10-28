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

        public IQueryable<Advert> GetAllByUser(IdentityUser user)
        {
            return GetAll().Where(advert => advert.Author.User == user);
        }

        public IQueryable<Advert> GetAllResolve()
        {
            return GetAll().Where(advert => advert.StatusActive == TypeStatusAdvert.resolved);
        }

        public IQueryable<Advert> GetAllResolveByUser(IdentityUser user)
        {
            return GetAllResolve().Where(advert => advert.Author.User == user);
        }
    }
}

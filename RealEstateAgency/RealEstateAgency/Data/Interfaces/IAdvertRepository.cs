using Microsoft.AspNetCore.Identity;
using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Data.Interfaces
{
    interface IAdvertRepository : IRepository<Advert>
    {
        IQueryable<Advert> GetAllWithType();
        IQueryable<Advert> GetAllWithTypeAndUser();
        Task<Advert> GetWithUserByIdAsync(int id);
        IQueryable<Advert> GetAllWithTypeByAgent(IdentityUser user);
        IQueryable<Advert> GetAllResolveWithType();

    }
}

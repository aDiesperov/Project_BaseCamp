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
        IQueryable<Advert> GetAllByUser(IdentityUser user);
        IQueryable<Advert> GetAllResolve();
        IQueryable<Advert> GetAllResolveByUser(IdentityUser user);

    }
}

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
    public class OfferRealEstateRepository : Repository<OfferRealEstate>, IOfferRealEstate
    {
        public OfferRealEstateRepository(ApplicationDbContext context) : base(context) { }
        
    }
}

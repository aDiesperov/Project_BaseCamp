using RealEstateAgency.Data.Interfaces;
using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Data.Repositories
{
    public class TypeRealEstateRepository : Repository<TypeRealEstate>, ITypeRealEstateRepository
    {
        public TypeRealEstateRepository(ApplicationDbContext context) : base(context) { }
    }
}

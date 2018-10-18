using Microsoft.AspNetCore.Identity;
using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Data.Interfaces
{
    interface IApplicationForRealEstateRepository : IRepository<ApplicationForRealEstate>
    {
        IEnumerable<ApplicationForRealEstate> GetMyApplication(IdentityUser User);
        Task<ApplicationForRealEstate> GetByIdWithUserAsync(int id);
    }
}

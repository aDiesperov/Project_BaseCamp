using RealEstateAgency.Data.Interfaces;
using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Data.Repositories
{
    public class ImgForAdvertRepository : Repository<ImgForAdvert>, IImgForAdvertRepository 
    {
        public ImgForAdvertRepository(ApplicationDbContext context) : base(context) { }
    }
}

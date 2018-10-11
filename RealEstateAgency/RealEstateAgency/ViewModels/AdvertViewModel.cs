using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.ViewModels
{
    public class AdvertViewModel
    {
        public IEnumerable<Advert> Adverts { get; set; }
        public IEnumerable<TypeRealEstate> TypeRealEstates { get; set; }
    }
}

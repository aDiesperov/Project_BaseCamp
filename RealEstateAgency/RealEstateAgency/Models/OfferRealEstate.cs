using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Models
{
    public class OfferRealEstate
    {
        public int OfferRealEstateId { get; set; }
        [Required]
        public virtual Advert Advert { get; set; }
        [Required]
        public virtual ApplicationForRealEstate ApplicationForRealEstate { get; set; }
        public TypeStatusOffer TypeStatusOffer { get; set; }
    }
}

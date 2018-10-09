using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Models
{
    public class VoteForRealEstate
    {
        public int VoteForRealEstateId { get; set; }
        public float Value { get; set; }
        [Required]
        public virtual Advert Advert { get; set; }
        [Required]
        public virtual IdentityUser Author { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
    }
}

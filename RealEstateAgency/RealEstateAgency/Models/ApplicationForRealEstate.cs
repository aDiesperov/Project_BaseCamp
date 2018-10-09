using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Models
{
    public class ApplicationForRealEstate
    {
        public int ApplicationForRealEstateId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public double? FromPrice { get; set; }
        [Column(TypeName = "money")]
        public double? ToPrice { get; set; }
        [Required]
        public virtual IdentityUser Author { get; set; }
        [Required]
        public virtual TypeRealEstate TypeRealEstate { get; set; }
        public byte? FromFloor { get; set; }
        public byte? ToFloor { get; set; }
        public byte? FromNumRooms { get; set; }
        public byte? ToNumRooms { get; set; }
        public float FromTotalArea { get; set; }
        public float ToTotalArea { get; set; }
        public float? FromKitchenArea { get; set; }
        public float? ToKitchenArea { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime DatePublication { get; set; }
        public bool Active { get; set; }
    }
}

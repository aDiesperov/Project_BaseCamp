using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.ViewModels
{
    public class ApplicationForRealEstateViewModel
    {
        [Required, StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Name { get; set; }
        [Required, MinLength(100, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Description { get; set; }
        public double? FromPrice { get; set; }
        public double? ToPrice { get; set; }
        [Required]
        public int TypeRealEstate { get; set; }
        public IEnumerable<TypeRealEstate> TypesRealEstate { get; set; }
        public byte? FromFloor { get; set; }
        public byte? ToFloor { get; set; }
        public byte? FromNumRooms { get; set; }
        public byte? ToNumRooms { get; set; }
        public float FromTotalArea { get; set; }
        public float ToTotalArea { get; set; }
        public float? FromKitchenArea { get; set; }
        public float? ToKitchenArea { get; set; }
    }
}

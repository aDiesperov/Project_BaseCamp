using Microsoft.AspNetCore.Http;
using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.ViewModels
{
    public class CreateAdvertViewModel
    {
        [Required, StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6 )]
        public string Name { get; set; }
        [Required, MinLength(100, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Description { get; set; }
        public double? Price { get; set; }
        [Required]
        [Display(Name = "Type Real Estate")]
        public int TypeRealEstate { get; set; }
        public IEnumerable<TypeRealEstate> TypesRealEstate { get; set; }
        public byte? Floor { get; set; }
        [Display(Name = "Number of stories")]
        public byte? NumStories { get; set; }
        [Display(Name = "Number of rooms")]
        public byte? NumRooms { get; set; }
        [Display(Name = "Totala area")]
        public float TotalArea { get; set; }
        [Display(Name = "Kitchen area")]
        public float? KitchenArea { get; set; }
        public bool Rent { get; set; }        
        public List<IFormFile> Files { get; set; }
    }
}

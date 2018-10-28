using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Models
{
    public class Advert
    {
        public int AdvertId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public double? Price { get; set; }
        [Required]
        public virtual Agent Author { get; set; }
        [Required]
        public virtual TypeRealEstate TypeRealEstate { get; set; }
        public byte? Floor { get; set; }
        public byte? NumStories { get; set; }
        public byte? NumRooms { get; set; }
        public float TotalArea { get; set; }
        public float? KitchenArea { get; set; }
        public float Rating { get; set; }
        public TypeStatusAdvert StatusActive { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime DateChangeStatus { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime DatePublication { get; set; }
        public bool Rent { get; set; }
        public virtual ICollection<ImgForAdvert> CollectionImgs { get; set; }
    }
}

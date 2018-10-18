using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Models
{
    public class ImgForAdvert
    {
        public int ImgForAdvertId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public virtual Advert Advert { get; set; }
    }
}
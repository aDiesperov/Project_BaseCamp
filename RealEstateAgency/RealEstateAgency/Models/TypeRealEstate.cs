using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Models
{
    public class TypeRealEstate
    {
        public int TypeRealEstateId { get; set; }
        [Required, StringLength(15)]
        public string Name { get; set; }
    }
}
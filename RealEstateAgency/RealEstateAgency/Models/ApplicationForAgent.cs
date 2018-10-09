using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Models
{
    public class ApplicationForAgent
    {
        public int ApplicationForAgentId { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime Date { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Models
{
    public class VoteForAgent
    {
        public int VoteForAgentId { get; set; }
        public float Value { get; set; }
        [Required]
        public virtual Agent Agent { get; set; }
        [Required]
        public virtual IdentityUser Author { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime Date { get; set; }
    }
}

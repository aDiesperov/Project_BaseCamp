using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        [Required]
        public string MessageText { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime Date { get; set; }
        [Required]
        public virtual IdentityUser FromUser { get; set; }
        [Required]
        public virtual IdentityUser ToUser { get; set; }
    }
}

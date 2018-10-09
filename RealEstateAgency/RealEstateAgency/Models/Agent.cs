using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgency.Models
{
    public class Agent
    {
        public int AgentId { get; set; }
        [Required]
        public virtual IdentityUser User { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public float Rating { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime DateChangeActive { get; set; }
    }
}
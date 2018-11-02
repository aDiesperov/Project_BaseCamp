using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Models;

namespace RealEstateAgency.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Message>().HasOne(m => m.FromUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Message>().HasOne(m => m.ToUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<VoteForAgent>().HasOne(v => v.Author).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<VoteForRealEstate>().HasOne(v => v.Author).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<OfferRealEstate>().HasOne(offer => offer.Advert).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<OfferRealEstate>().HasOne(offer => offer.ApplicationForRealEstate).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<ApplicationForAgent> ApplicationForAgents { get; set; }
        public DbSet<ApplicationForRealEstate> ApplicationForRealEstates { get; set; }
        public DbSet<ImgForAdvert> ImgForAdverts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<TypeRealEstate> TypeRealEstates { get; set; }
        public DbSet<VoteForAgent> VoteForAgents { get; set; }
        public DbSet<VoteForRealEstate> VoteForRealEstates { get; set; }
        public DbSet<OfferRealEstate> OfferRealEstates { get; set; }
    }
}

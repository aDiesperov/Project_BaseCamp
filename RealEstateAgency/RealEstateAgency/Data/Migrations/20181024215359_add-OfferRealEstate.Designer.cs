﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstateAgency.Data;

namespace RealEstateAgency.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181024215359_add-OfferRealEstate")]
    partial class addOfferRealEstate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RealEstateAgency.Models.Advert", b =>
                {
                    b.Property<int>("AdvertId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorAgentId");

                    b.Property<DateTime>("DateChangeStatus")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("DatePublication")
                        .HasColumnType("DateTime");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<byte?>("Floor");

                    b.Property<float?>("KitchenArea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte?>("NumRooms");

                    b.Property<byte?>("NumStories");

                    b.Property<decimal?>("Price")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("money");

                    b.Property<float>("Rating");

                    b.Property<bool>("Rent");

                    b.Property<byte>("StatusActive");

                    b.Property<float>("TotalArea");

                    b.Property<int>("TypeRealEstateId");

                    b.HasKey("AdvertId");

                    b.HasIndex("AuthorAgentId");

                    b.HasIndex("TypeRealEstateId");

                    b.ToTable("Adverts");
                });

            modelBuilder.Entity("RealEstateAgency.Models.Agent", b =>
                {
                    b.Property<int>("AgentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("DateChangeActive")
                        .HasColumnType("DateTime");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<float>("Rating");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("AgentId");

                    b.HasIndex("UserId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("RealEstateAgency.Models.ApplicationForAgent", b =>
                {
                    b.Property<int>("ApplicationForAgentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DateTime");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("ApplicationForAgentId");

                    b.HasIndex("UserId");

                    b.ToTable("ApplicationForAgents");
                });

            modelBuilder.Entity("RealEstateAgency.Models.ApplicationForRealEstate", b =>
                {
                    b.Property<int>("ApplicationForRealEstateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("AuthorId")
                        .IsRequired();

                    b.Property<DateTime>("DatePublication")
                        .HasColumnType("DateTime");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<byte?>("FromFloor");

                    b.Property<float?>("FromKitchenArea");

                    b.Property<byte?>("FromNumRooms");

                    b.Property<decimal?>("FromPrice")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("money");

                    b.Property<float>("FromTotalArea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte?>("ToFloor");

                    b.Property<float?>("ToKitchenArea");

                    b.Property<byte?>("ToNumRooms");

                    b.Property<decimal?>("ToPrice")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("money");

                    b.Property<float>("ToTotalArea");

                    b.Property<int>("TypeRealEstateId");

                    b.HasKey("ApplicationForRealEstateId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TypeRealEstateId");

                    b.ToTable("ApplicationForRealEstates");
                });

            modelBuilder.Entity("RealEstateAgency.Models.ImgForAdvert", b =>
                {
                    b.Property<int>("ImgForAdvertId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvertId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ImgForAdvertId");

                    b.HasIndex("AdvertId");

                    b.ToTable("ImgForAdverts");
                });

            modelBuilder.Entity("RealEstateAgency.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("DateTime");

                    b.Property<string>("FromUserId")
                        .IsRequired();

                    b.Property<string>("MessageText")
                        .IsRequired();

                    b.Property<string>("ToUserId")
                        .IsRequired();

                    b.HasKey("MessageId");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("RealEstateAgency.Models.OfferRealEstate", b =>
                {
                    b.Property<int>("OfferRealEstateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvertId");

                    b.Property<int>("ApplicationForRealEstateId");

                    b.Property<byte>("TypeStatusOffer");

                    b.HasKey("OfferRealEstateId");

                    b.HasIndex("AdvertId");

                    b.HasIndex("ApplicationForRealEstateId");

                    b.ToTable("OfferRealEstates");
                });

            modelBuilder.Entity("RealEstateAgency.Models.TypeRealEstate", b =>
                {
                    b.Property<int>("TypeRealEstateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("TypeRealEstateId");

                    b.ToTable("TypeRealEstates");
                });

            modelBuilder.Entity("RealEstateAgency.Models.VoteForAgent", b =>
                {
                    b.Property<int>("VoteForAgentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgentId");

                    b.Property<string>("AuthorId")
                        .IsRequired();

                    b.Property<DateTime>("Date")
                        .HasColumnType("DateTime");

                    b.Property<float>("Value");

                    b.HasKey("VoteForAgentId");

                    b.HasIndex("AgentId");

                    b.HasIndex("AuthorId");

                    b.ToTable("VoteForAgents");
                });

            modelBuilder.Entity("RealEstateAgency.Models.VoteForRealEstate", b =>
                {
                    b.Property<int>("VoteForRealEstateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvertId");

                    b.Property<string>("AuthorId")
                        .IsRequired();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<float>("Value");

                    b.HasKey("VoteForRealEstateId");

                    b.HasIndex("AdvertId");

                    b.HasIndex("AuthorId");

                    b.ToTable("VoteForRealEstates");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RealEstateAgency.Models.Advert", b =>
                {
                    b.HasOne("RealEstateAgency.Models.Agent", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorAgentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RealEstateAgency.Models.TypeRealEstate", "TypeRealEstate")
                        .WithMany()
                        .HasForeignKey("TypeRealEstateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RealEstateAgency.Models.Agent", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RealEstateAgency.Models.ApplicationForAgent", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RealEstateAgency.Models.ApplicationForRealEstate", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RealEstateAgency.Models.TypeRealEstate", "TypeRealEstate")
                        .WithMany()
                        .HasForeignKey("TypeRealEstateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RealEstateAgency.Models.ImgForAdvert", b =>
                {
                    b.HasOne("RealEstateAgency.Models.Advert", "Advert")
                        .WithMany("CollectionImgs")
                        .HasForeignKey("AdvertId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RealEstateAgency.Models.Message", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("RealEstateAgency.Models.OfferRealEstate", b =>
                {
                    b.HasOne("RealEstateAgency.Models.Advert", "Advert")
                        .WithMany()
                        .HasForeignKey("AdvertId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RealEstateAgency.Models.ApplicationForRealEstate", "ApplicationForRealEstate")
                        .WithMany()
                        .HasForeignKey("ApplicationForRealEstateId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("RealEstateAgency.Models.VoteForAgent", b =>
                {
                    b.HasOne("RealEstateAgency.Models.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("RealEstateAgency.Models.VoteForRealEstate", b =>
                {
                    b.HasOne("RealEstateAgency.Models.Advert", "Advert")
                        .WithMany()
                        .HasForeignKey("AdvertId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

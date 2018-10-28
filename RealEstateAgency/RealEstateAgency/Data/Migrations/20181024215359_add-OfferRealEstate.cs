using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateAgency.Data.Migrations
{
    public partial class addOfferRealEstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfferRealEstates",
                columns: table => new
                {
                    OfferRealEstateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdvertId = table.Column<int>(nullable: false),
                    ApplicationForRealEstateId = table.Column<int>(nullable: false),
                    TypeStatusOffer = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferRealEstates", x => x.OfferRealEstateId);
                    table.ForeignKey(
                        name: "FK_OfferRealEstates_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "AdvertId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferRealEstates_ApplicationForRealEstates_ApplicationForRealEstateId",
                        column: x => x.ApplicationForRealEstateId,
                        principalTable: "ApplicationForRealEstates",
                        principalColumn: "ApplicationForRealEstateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferRealEstates_AdvertId",
                table: "OfferRealEstates",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferRealEstates_ApplicationForRealEstateId",
                table: "OfferRealEstates",
                column: "ApplicationForRealEstateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferRealEstates");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateAgency.Data.Migrations
{
    public partial class firstModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    DateChangeActive = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                    table.ForeignKey(
                        name: "FK_Agents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationForAgents",
                columns: table => new
                {
                    ApplicationForAgentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForAgents", x => x.ApplicationForAgentId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MessageText = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FromUserId = table.Column<string>(nullable: false),
                    ToUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeRealEstates",
                columns: table => new
                {
                    TypeRealEstateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRealEstates", x => x.TypeRealEstateId);
                });

            migrationBuilder.CreateTable(
                name: "VoteForAgents",
                columns: table => new
                {
                    VoteForAgentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<float>(nullable: false),
                    AgentId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteForAgents", x => x.VoteForAgentId);
                    table.ForeignKey(
                        name: "FK_VoteForAgents_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoteForAgents_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    AdvertId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    AuthorAgentId = table.Column<int>(nullable: false),
                    TypeRealEstateId = table.Column<int>(nullable: false),
                    Floor = table.Column<byte>(nullable: true),
                    NumStories = table.Column<byte>(nullable: true),
                    NumRooms = table.Column<byte>(nullable: true),
                    TotalArea = table.Column<float>(nullable: false),
                    KitchenArea = table.Column<float>(nullable: true),
                    Rating = table.Column<float>(nullable: false),
                    StatusActive = table.Column<byte>(nullable: false),
                    DateChangeStatus = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DatePublication = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Rent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.AdvertId);
                    table.ForeignKey(
                        name: "FK_Adverts_Agents_AuthorAgentId",
                        column: x => x.AuthorAgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_TypeRealEstates_TypeRealEstateId",
                        column: x => x.TypeRealEstateId,
                        principalTable: "TypeRealEstates",
                        principalColumn: "TypeRealEstateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationForRealEstates",
                columns: table => new
                {
                    ApplicationForRealEstateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    FromPrice = table.Column<decimal>(type: "money", nullable: true),
                    ToPrice = table.Column<decimal>(type: "money", nullable: true),
                    AuthorId = table.Column<string>(nullable: false),
                    TypeRealEstateId = table.Column<int>(nullable: false),
                    FromFloor = table.Column<byte>(nullable: true),
                    ToFloor = table.Column<byte>(nullable: true),
                    FromNumRooms = table.Column<byte>(nullable: true),
                    ToNumRooms = table.Column<byte>(nullable: true),
                    FromTotalArea = table.Column<float>(nullable: false),
                    ToTotalArea = table.Column<float>(nullable: false),
                    FromKitchenArea = table.Column<float>(nullable: true),
                    ToKitchenArea = table.Column<float>(nullable: true),
                    DatePublication = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForRealEstates", x => x.ApplicationForRealEstateId);
                    table.ForeignKey(
                        name: "FK_ApplicationForRealEstates_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationForRealEstates_TypeRealEstates_TypeRealEstateId",
                        column: x => x.TypeRealEstateId,
                        principalTable: "TypeRealEstates",
                        principalColumn: "TypeRealEstateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImgForAdverts",
                columns: table => new
                {
                    ImgForAdvertId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    AdvertId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgForAdverts", x => x.ImgForAdvertId);
                    table.ForeignKey(
                        name: "FK_ImgForAdverts_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "AdvertId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoteForRealEstates",
                columns: table => new
                {
                    VoteForRealEstateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<float>(nullable: false),
                    AdvertId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteForRealEstates", x => x.VoteForRealEstateId);
                    table.ForeignKey(
                        name: "FK_VoteForRealEstates_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "AdvertId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoteForRealEstates_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_AuthorAgentId",
                table: "Adverts",
                column: "AuthorAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_TypeRealEstateId",
                table: "Adverts",
                column: "TypeRealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForRealEstates_AuthorId",
                table: "ApplicationForRealEstates",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForRealEstates_TypeRealEstateId",
                table: "ApplicationForRealEstates",
                column: "TypeRealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_ImgForAdverts_AdvertId",
                table: "ImgForAdverts",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromUserId",
                table: "Messages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToUserId",
                table: "Messages",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteForAgents_AgentId",
                table: "VoteForAgents",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteForAgents_AuthorId",
                table: "VoteForAgents",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteForRealEstates_AdvertId",
                table: "VoteForRealEstates",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteForRealEstates_AuthorId",
                table: "VoteForRealEstates",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationForAgents");

            migrationBuilder.DropTable(
                name: "ApplicationForRealEstates");

            migrationBuilder.DropTable(
                name: "ImgForAdverts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "VoteForAgents");

            migrationBuilder.DropTable(
                name: "VoteForRealEstates");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "TypeRealEstates");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}

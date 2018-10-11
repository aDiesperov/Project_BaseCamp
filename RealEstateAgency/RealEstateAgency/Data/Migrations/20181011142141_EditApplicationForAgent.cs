using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateAgency.Data.Migrations
{
    public partial class EditApplicationForAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ApplicationForAgents",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForAgents_UserId",
                table: "ApplicationForAgents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationForAgents_AspNetUsers_UserId",
                table: "ApplicationForAgents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationForAgents_AspNetUsers_UserId",
                table: "ApplicationForAgents");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationForAgents_UserId",
                table: "ApplicationForAgents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ApplicationForAgents");
        }
    }
}

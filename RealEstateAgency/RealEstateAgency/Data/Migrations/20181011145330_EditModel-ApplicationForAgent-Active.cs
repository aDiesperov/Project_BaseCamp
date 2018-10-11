using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateAgency.Data.Migrations
{
    public partial class EditModelApplicationForAgentActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ApplicationForAgents",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "ApplicationForAgents");
        }
    }
}

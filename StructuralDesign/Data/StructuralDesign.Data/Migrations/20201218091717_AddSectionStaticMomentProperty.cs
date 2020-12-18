using Microsoft.EntityFrameworkCore.Migrations;

namespace StructuralDesign.Data.Migrations
{
    public partial class AddSectionStaticMomentProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "StaticMomentY",
                table: "Sections",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "StaticMomentZ",
                table: "Sections",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaticMomentY",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "StaticMomentZ",
                table: "Sections");
        }
    }
}

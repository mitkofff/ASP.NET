using Microsoft.EntityFrameworkCore.Migrations;

namespace StructuralDesign.Data.Migrations
{
    public partial class AddIsApprovedForBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "IsApproved",
                table: "Books",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Books");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace StructuralDesign.Data.Migrations
{
    public partial class AddIsApprovedForBooksBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsApproved",
                table: "Books",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "IsApproved",
                table: "Books",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace StructuralDesign.Data.Migrations
{
    public partial class AddRelationElementToBolt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BoltId",
                table: "Elements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Elements_BoltId",
                table: "Elements",
                column: "BoltId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_Bolts_BoltId",
                table: "Elements",
                column: "BoltId",
                principalTable: "Bolts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_Bolts_BoltId",
                table: "Elements");

            migrationBuilder.DropIndex(
                name: "IX_Elements_BoltId",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "BoltId",
                table: "Elements");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Elements",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}

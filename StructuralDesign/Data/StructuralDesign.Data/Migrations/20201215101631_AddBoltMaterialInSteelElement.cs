using Microsoft.EntityFrameworkCore.Migrations;

namespace StructuralDesign.Data.Migrations
{
    public partial class AddBoltMaterialInSteelElement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_SteelElements_ElementSteelId",
                table: "Loads");

            migrationBuilder.DropIndex(
                name: "IX_Loads_ElementSteelId",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "ElementSteelId",
                table: "Loads");

            migrationBuilder.AddColumn<int>(
                name: "LoadId",
                table: "SteelElements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SteelElements_LoadId",
                table: "SteelElements",
                column: "LoadId");

            migrationBuilder.AddForeignKey(
                name: "FK_SteelElements_Loads_LoadId",
                table: "SteelElements",
                column: "LoadId",
                principalTable: "Loads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SteelElements_Loads_LoadId",
                table: "SteelElements");

            migrationBuilder.DropIndex(
                name: "IX_SteelElements_LoadId",
                table: "SteelElements");

            migrationBuilder.DropColumn(
                name: "LoadId",
                table: "SteelElements");

            migrationBuilder.AddColumn<string>(
                name: "ElementSteelId",
                table: "Loads",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loads_ElementSteelId",
                table: "Loads",
                column: "ElementSteelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_SteelElements_ElementSteelId",
                table: "Loads",
                column: "ElementSteelId",
                principalTable: "SteelElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

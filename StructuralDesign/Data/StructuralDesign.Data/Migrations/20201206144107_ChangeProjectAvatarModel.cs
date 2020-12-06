using Microsoft.EntityFrameworkCore.Migrations;

namespace StructuralDesign.Data.Migrations
{
    public partial class ChangeProjectAvatarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectAvatars_ProjectAvatarId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectAvatarId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectAvatarId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "ProjectAvatars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAvatars_ProjectId",
                table: "ProjectAvatars",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectAvatars_Projects_ProjectId",
                table: "ProjectAvatars",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectAvatars_Projects_ProjectId",
                table: "ProjectAvatars");

            migrationBuilder.DropIndex(
                name: "IX_ProjectAvatars_ProjectId",
                table: "ProjectAvatars");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectAvatars");

            migrationBuilder.AddColumn<string>(
                name: "ProjectAvatarId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectAvatarId",
                table: "Projects",
                column: "ProjectAvatarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectAvatars_ProjectAvatarId",
                table: "Projects",
                column: "ProjectAvatarId",
                principalTable: "ProjectAvatars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

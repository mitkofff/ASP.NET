using Microsoft.EntityFrameworkCore.Migrations;

namespace StructuralDesign.Data.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Bolts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    NominalDiameter = table.Column<int>(nullable: false),
                    NetoDiameter = table.Column<decimal>(nullable: false),
                    GrossArea = table.Column<decimal>(nullable: false),
                    NetoArea = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    YieldStrength = table.Column<decimal>(nullable: false),
                    UltimateTensile = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    FlangeThickness = table.Column<decimal>(nullable: true),
                    WebThickness = table.Column<decimal>(nullable: true),
                    Area = table.Column<decimal>(nullable: false),
                    InertialMomentY = table.Column<decimal>(nullable: false),
                    InertialMomentZ = table.Column<decimal>(nullable: false),
                    ResistanceMomentY = table.Column<decimal>(nullable: false),
                    ResistanceMomentZ = table.Column<decimal>(nullable: false),
                    InertialRadiusY = table.Column<decimal>(nullable: false),
                    InertialRadiusZ = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    Length = table.Column<decimal>(nullable: true),
                    AxialForce = table.Column<decimal>(nullable: true),
                    ShearForceY = table.Column<decimal>(nullable: true),
                    ShearForceZ = table.Column<decimal>(nullable: true),
                    BendingMomentY = table.Column<decimal>(nullable: true),
                    BendingMomentZ = table.Column<decimal>(nullable: true),
                    ResultFactor = table.Column<decimal>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    ProjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elements_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elements_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elements_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elements_MaterialId",
                table: "Elements",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_ProjectId",
                table: "Elements",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_SectionId",
                table: "Elements",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ApplicationUserId",
                table: "Projects",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bolts");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}

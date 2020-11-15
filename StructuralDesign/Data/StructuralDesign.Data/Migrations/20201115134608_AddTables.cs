using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StructuralDesign.Data.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
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
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    NominalDiameter = table.Column<int>(nullable: false),
                    NetoDiameter = table.Column<decimal>(nullable: false),
                    NetoArea = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialConcretes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    VolumeWeight = table.Column<decimal>(nullable: false),
                    DesignCompressiveStrength = table.Column<decimal>(nullable: false),
                    DesignTensionStrength = table.Column<decimal>(nullable: false),
                    ModulusOfElasticity = table.Column<decimal>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialConcretes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialConcretes_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialRebars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    YieldStrength = table.Column<decimal>(nullable: false),
                    PartialSafetyFactor = table.Column<decimal>(nullable: false),
                    VolumeWeight = table.Column<decimal>(nullable: false),
                    ModulusOfElasticity = table.Column<decimal>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialRebars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialRebars_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialSoils",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    VolumeWeight = table.Column<decimal>(nullable: false),
                    DesignPressure = table.Column<decimal>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSoils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialSoils_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialSteels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    YieldStrength = table.Column<decimal>(nullable: false),
                    UltimateTensile = table.Column<decimal>(nullable: false),
                    VolumeWeight = table.Column<decimal>(nullable: false),
                    ModulusOfElasticity = table.Column<decimal>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSteels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialSteels_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAvatars",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAvatars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectAvatars_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReinforcementBar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Diameter = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReinforcementBar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
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
                name: "UserAvatars",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAvatars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAvatars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProjectAvatarId = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectAvatars_ProjectAvatarId",
                        column: x => x.ProjectAvatarId,
                        principalTable: "ProjectAvatars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SteelElements",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: false),
                    SteelId = table.Column<int>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    LeftBoundaryCondition = table.Column<int>(nullable: false),
                    RightBoundaryCondition = table.Column<int>(nullable: false),
                    BoltId = table.Column<int>(nullable: false),
                    MaterialBoltId = table.Column<int>(nullable: false),
                    ResultFactor = table.Column<decimal>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    ProjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteelElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SteelElements_Bolts_BoltId",
                        column: x => x.BoltId,
                        principalTable: "Bolts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SteelElements_MaterialSteels_MaterialBoltId",
                        column: x => x.MaterialBoltId,
                        principalTable: "MaterialSteels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SteelElements_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SteelElements_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SteelElements_MaterialSteels_SteelId",
                        column: x => x.SteelId,
                        principalTable: "MaterialSteels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    AxialForce = table.Column<decimal>(nullable: true),
                    ShearForceY = table.Column<decimal>(nullable: true),
                    ShearForceZ = table.Column<decimal>(nullable: true),
                    BendingMomentY = table.Column<decimal>(nullable: true),
                    BendingMomentZ = table.Column<decimal>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ElementSteelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loads_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loads_SteelElements_ElementSteelId",
                        column: x => x.ElementSteelId,
                        principalTable: "SteelElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteElements",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    LeftBoundaryCondition = table.Column<int>(nullable: false),
                    RightBoundaryCondition = table.Column<int>(nullable: false),
                    LoadId = table.Column<int>(nullable: false),
                    ConcreteId = table.Column<int>(nullable: false),
                    MaterialRebarId = table.Column<int>(nullable: false),
                    ReinforcementBarId = table.Column<int>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    ProjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcreteElements_MaterialConcretes_ConcreteId",
                        column: x => x.ConcreteId,
                        principalTable: "MaterialConcretes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConcreteElements_Loads_LoadId",
                        column: x => x.LoadId,
                        principalTable: "Loads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConcreteElements_MaterialRebars_MaterialRebarId",
                        column: x => x.MaterialRebarId,
                        principalTable: "MaterialRebars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConcreteElements_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConcreteElements_ReinforcementBar_ReinforcementBarId",
                        column: x => x.ReinforcementBarId,
                        principalTable: "ReinforcementBar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConcreteElements_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Foundations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    HeightOfBackFill = table.Column<decimal>(nullable: false),
                    LoadId = table.Column<int>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    SoilId = table.Column<int>(nullable: false),
                    ConcreteId = table.Column<int>(nullable: false),
                    MaterialRebarId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foundations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foundations_MaterialConcretes_ConcreteId",
                        column: x => x.ConcreteId,
                        principalTable: "MaterialConcretes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foundations_Loads_LoadId",
                        column: x => x.LoadId,
                        principalTable: "Loads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foundations_MaterialRebars_MaterialRebarId",
                        column: x => x.MaterialRebarId,
                        principalTable: "MaterialRebars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foundations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foundations_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foundations_MaterialSoils_SoilId",
                        column: x => x.SoilId,
                        principalTable: "MaterialSoils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_IsDeleted",
                table: "Books",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteElements_ConcreteId",
                table: "ConcreteElements",
                column: "ConcreteId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteElements_LoadId",
                table: "ConcreteElements",
                column: "LoadId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteElements_MaterialRebarId",
                table: "ConcreteElements",
                column: "MaterialRebarId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteElements_ProjectId",
                table: "ConcreteElements",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteElements_ReinforcementBarId",
                table: "ConcreteElements",
                column: "ReinforcementBarId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteElements_SectionId",
                table: "ConcreteElements",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Foundations_ConcreteId",
                table: "Foundations",
                column: "ConcreteId");

            migrationBuilder.CreateIndex(
                name: "IX_Foundations_LoadId",
                table: "Foundations",
                column: "LoadId");

            migrationBuilder.CreateIndex(
                name: "IX_Foundations_MaterialRebarId",
                table: "Foundations",
                column: "MaterialRebarId");

            migrationBuilder.CreateIndex(
                name: "IX_Foundations_ProjectId",
                table: "Foundations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Foundations_SectionId",
                table: "Foundations",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Foundations_SoilId",
                table: "Foundations",
                column: "SoilId");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_CreatorId",
                table: "Loads",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_ElementSteelId",
                table: "Loads",
                column: "ElementSteelId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialConcretes_CreatorId",
                table: "MaterialConcretes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialConcretes_IsDeleted",
                table: "MaterialConcretes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRebars_CreatorId",
                table: "MaterialRebars",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRebars_IsDeleted",
                table: "MaterialRebars",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSoils_CreatorId",
                table: "MaterialSoils",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSoils_IsDeleted",
                table: "MaterialSoils",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSteels_CreatorId",
                table: "MaterialSteels",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSteels_IsDeleted",
                table: "MaterialSteels",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAvatars_CreatorId",
                table: "ProjectAvatars",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAvatars_IsDeleted",
                table: "ProjectAvatars",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IsDeleted",
                table: "Projects",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OwnerId",
                table: "Projects",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectAvatarId",
                table: "Projects",
                column: "ProjectAvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_IsDeleted",
                table: "Sections",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SteelElements_BoltId",
                table: "SteelElements",
                column: "BoltId");

            migrationBuilder.CreateIndex(
                name: "IX_SteelElements_IsDeleted",
                table: "SteelElements",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SteelElements_MaterialBoltId",
                table: "SteelElements",
                column: "MaterialBoltId");

            migrationBuilder.CreateIndex(
                name: "IX_SteelElements_ProjectId",
                table: "SteelElements",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SteelElements_SectionId",
                table: "SteelElements",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SteelElements_SteelId",
                table: "SteelElements",
                column: "SteelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAvatars_IsDeleted",
                table: "UserAvatars",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserAvatars_UserId",
                table: "UserAvatars",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "ConcreteElements");

            migrationBuilder.DropTable(
                name: "Foundations");

            migrationBuilder.DropTable(
                name: "UserAvatars");

            migrationBuilder.DropTable(
                name: "ReinforcementBar");

            migrationBuilder.DropTable(
                name: "MaterialConcretes");

            migrationBuilder.DropTable(
                name: "Loads");

            migrationBuilder.DropTable(
                name: "MaterialRebars");

            migrationBuilder.DropTable(
                name: "MaterialSoils");

            migrationBuilder.DropTable(
                name: "SteelElements");

            migrationBuilder.DropTable(
                name: "Bolts");

            migrationBuilder.DropTable(
                name: "MaterialSteels");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "ProjectAvatars");

            migrationBuilder.DropColumn(
                name: "CompanyName",
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

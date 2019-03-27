using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCWebAppKenney.Data.Migrations
{
    public partial class AddedClassificationAndCrop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    ClassificationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.ClassificationID);
                });

            migrationBuilder.CreateTable(
                name: "Farm",
                columns: table => new
                {
                    FarmID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FarmName = table.Column<string>(nullable: true),
                    FarmAddress = table.Column<string>(nullable: true),
                    FarmSize = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farm", x => x.FarmID);
                });

            migrationBuilder.CreateTable(
                name: "Crop",
                columns: table => new
                {
                    CropID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CropName = table.Column<string>(nullable: true),
                    CropVariety = table.Column<string>(nullable: true),
                    ClassificationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crop", x => x.CropID);
                    table.ForeignKey(
                        name: "FK_Crop_Classifications_ClassificationID",
                        column: x => x.ClassificationID,
                        principalTable: "Classifications",
                        principalColumn: "ClassificationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crop_ClassificationID",
                table: "Crop",
                column: "ClassificationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crop");

            migrationBuilder.DropTable(
                name: "Farm");

            migrationBuilder.DropTable(
                name: "Classifications");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCWebAppKenney.Data.Migrations
{
    public partial class AddedCanProduce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CanProduce",
                columns: table => new
                {
                    CanProduceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CropID = table.Column<int>(nullable: false),
                    FarmID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanProduce", x => x.CanProduceID);
                    table.ForeignKey(
                        name: "FK_CanProduce_Crop_CropID",
                        column: x => x.CropID,
                        principalTable: "Crop",
                        principalColumn: "CropID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CanProduce_Farm_FarmID",
                        column: x => x.FarmID,
                        principalTable: "Farm",
                        principalColumn: "FarmID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CanProduce_CropID",
                table: "CanProduce",
                column: "CropID");

            migrationBuilder.CreateIndex(
                name: "IX_CanProduce_FarmID",
                table: "CanProduce",
                column: "FarmID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CanProduce");
        }
    }
}

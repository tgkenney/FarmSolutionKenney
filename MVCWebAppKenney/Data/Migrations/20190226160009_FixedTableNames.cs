using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCWebAppKenney.Data.Migrations
{
    public partial class FixedTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CanProduce_Crop_CropID",
                table: "CanProduce");

            migrationBuilder.DropForeignKey(
                name: "FK_CanProduce_Farm_FarmID",
                table: "CanProduce");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Classifications_ClassificationID",
                table: "Crop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Farm",
                table: "Farm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crop",
                table: "Crop");

            migrationBuilder.RenameTable(
                name: "Farm",
                newName: "Farms");

            migrationBuilder.RenameTable(
                name: "Crop",
                newName: "Crops");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_ClassificationID",
                table: "Crops",
                newName: "IX_Crops_ClassificationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Farms",
                table: "Farms",
                column: "FarmID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crops",
                table: "Crops",
                column: "CropID");

            migrationBuilder.AddForeignKey(
                name: "FK_CanProduce_Crops_CropID",
                table: "CanProduce",
                column: "CropID",
                principalTable: "Crops",
                principalColumn: "CropID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CanProduce_Farms_FarmID",
                table: "CanProduce",
                column: "FarmID",
                principalTable: "Farms",
                principalColumn: "FarmID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Classifications_ClassificationID",
                table: "Crops",
                column: "ClassificationID",
                principalTable: "Classifications",
                principalColumn: "ClassificationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CanProduce_Crops_CropID",
                table: "CanProduce");

            migrationBuilder.DropForeignKey(
                name: "FK_CanProduce_Farms_FarmID",
                table: "CanProduce");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Classifications_ClassificationID",
                table: "Crops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Farms",
                table: "Farms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crops",
                table: "Crops");

            migrationBuilder.RenameTable(
                name: "Farms",
                newName: "Farm");

            migrationBuilder.RenameTable(
                name: "Crops",
                newName: "Crop");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_ClassificationID",
                table: "Crop",
                newName: "IX_Crop_ClassificationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Farm",
                table: "Farm",
                column: "FarmID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crop",
                table: "Crop",
                column: "CropID");

            migrationBuilder.AddForeignKey(
                name: "FK_CanProduce_Crop_CropID",
                table: "CanProduce",
                column: "CropID",
                principalTable: "Crop",
                principalColumn: "CropID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CanProduce_Farm_FarmID",
                table: "CanProduce",
                column: "FarmID",
                principalTable: "Farm",
                principalColumn: "FarmID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Classifications_ClassificationID",
                table: "Crop",
                column: "ClassificationID",
                principalTable: "Classifications",
                principalColumn: "ClassificationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

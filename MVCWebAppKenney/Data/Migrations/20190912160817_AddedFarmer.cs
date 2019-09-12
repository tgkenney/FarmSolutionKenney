using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCWebAppKenney.Data.Migrations
{
    public partial class AddedFarmer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FarmID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FarmID",
                table: "AspNetUsers",
                column: "FarmID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Farms_FarmID",
                table: "AspNetUsers",
                column: "FarmID",
                principalTable: "Farms",
                principalColumn: "FarmID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Farms_FarmID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FarmID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FarmID",
                table: "AspNetUsers");
        }
    }
}

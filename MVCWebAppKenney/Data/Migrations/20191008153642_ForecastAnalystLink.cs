using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCWebAppKenney.Data.Migrations
{
    public partial class ForecastAnalystLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Forecasts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Forecasts_Id",
                table: "Forecasts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Forecasts_AspNetUsers_Id",
                table: "Forecasts",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forecasts_AspNetUsers_Id",
                table: "Forecasts");

            migrationBuilder.DropIndex(
                name: "IX_Forecasts_Id",
                table: "Forecasts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Forecasts");
        }
    }
}

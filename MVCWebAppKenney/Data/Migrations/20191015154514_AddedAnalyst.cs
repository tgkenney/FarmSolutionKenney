using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCWebAppKenney.Data.Migrations
{
    public partial class AddedAnalyst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnalystId",
                table: "Forecasts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Forecasts_AnalystId",
                table: "Forecasts",
                column: "AnalystId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forecasts_AspNetUsers_AnalystId",
                table: "Forecasts",
                column: "AnalystId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forecasts_AspNetUsers_AnalystId",
                table: "Forecasts");

            migrationBuilder.DropIndex(
                name: "IX_Forecasts_AnalystId",
                table: "Forecasts");

            migrationBuilder.DropColumn(
                name: "AnalystId",
                table: "Forecasts");
        }
    }
}

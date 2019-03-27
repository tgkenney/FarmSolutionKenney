using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCWebAppKenney.Data.Migrations
{
    public partial class AddedForecasts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    ForecastID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ForecastAmount = table.Column<double>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ActualSales = table.Column<double>(nullable: true),
                    CropID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.ForecastID);
                    table.ForeignKey(
                        name: "FK_Forecasts_Crops_CropID",
                        column: x => x.CropID,
                        principalTable: "Crops",
                        principalColumn: "CropID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forecasts_CropID",
                table: "Forecasts",
                column: "CropID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forecasts");
        }
    }
}

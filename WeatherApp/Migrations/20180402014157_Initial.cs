using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeatherApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    ZIP = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Day = table.Column<DateTime>(nullable: false),
                    AirPressure = table.Column<decimal>(nullable: false),
                    FeelsLike = table.Column<decimal>(nullable: false),
                    Humidity = table.Column<decimal>(nullable: false),
                    Temperature = table.Column<decimal>(nullable: false),
                    UVIndex = table.Column<decimal>(nullable: false),
                    Visibility = table.Column<decimal>(nullable: false),
                    WindDirection = table.Column<decimal>(nullable: false),
                    WindSpeed = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => new { x.ZIP, x.City, x.State, x.Day });
                    table.UniqueConstraint("AK_Weather_City_Day_State_ZIP", x => new { x.City, x.Day, x.State, x.ZIP });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");
        }
    }
}

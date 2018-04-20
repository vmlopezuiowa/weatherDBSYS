using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeatherApp.Data.Migrations
{
    public partial class rev11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Weather_City_Day_State_ZIP",
                table: "Weather");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weather",
                table: "Weather");

            migrationBuilder.AlterColumn<decimal>(
                name: "WindSpeed",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Visibility",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "UVIndex",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Temperature",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Sunset",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Sunrise",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Moonset",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Moonrise",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<decimal>(
                name: "Humidity",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "FeelsLike",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "AirPressure",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Weather_Day_ZIP",
                table: "Weather",
                columns: new[] { "Day", "ZIP" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weather",
                table: "Weather",
                columns: new[] { "ZIP", "Day" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Weather_Day_ZIP",
                table: "Weather");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weather",
                table: "Weather");

            migrationBuilder.AlterColumn<decimal>(
                name: "WindSpeed",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Visibility",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UVIndex",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Temperature",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Sunset",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Sunrise",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Moonset",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Moonrise",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Humidity",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FeelsLike",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AirPressure",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Weather_City_Day_State_ZIP",
                table: "Weather",
                columns: new[] { "City", "Day", "State", "ZIP" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weather",
                table: "Weather",
                columns: new[] { "ZIP", "City", "State", "Day" });
        }
    }
}

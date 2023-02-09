using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorTimeCalculator.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ob50Limit",
                table: "WorkUnits");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "WorkReports",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "WorkReports");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Ob50Limit",
                table: "WorkUnits",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}

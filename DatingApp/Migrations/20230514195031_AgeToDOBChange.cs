using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingApp.Migrations
{
    public partial class AgeToDOBChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "StandardApplicationUser");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "StandardApplicationUser",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "StandardApplicationUser");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "StandardApplicationUser",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

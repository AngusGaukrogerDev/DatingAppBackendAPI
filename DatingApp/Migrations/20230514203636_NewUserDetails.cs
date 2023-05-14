using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingApp.Migrations
{
    public partial class NewUserDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "StandardApplicationUser",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "StandardApplicationUser",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hometown",
                table: "StandardApplicationUser",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "StandardApplicationUser",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "StandardApplicationUser",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniversityName",
                table: "StandardApplicationUser",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "StandardApplicationUser");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "StandardApplicationUser");

            migrationBuilder.DropColumn(
                name: "Hometown",
                table: "StandardApplicationUser");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "StandardApplicationUser");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "StandardApplicationUser");

            migrationBuilder.DropColumn(
                name: "UniversityName",
                table: "StandardApplicationUser");
        }
    }
}

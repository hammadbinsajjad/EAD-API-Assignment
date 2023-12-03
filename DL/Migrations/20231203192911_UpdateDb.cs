using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "studentDbDto",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "studentDbDto",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RollNumber",
                table: "studentDbDto",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "studentDbDto");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "studentDbDto");

            migrationBuilder.DropColumn(
                name: "RollNumber",
                table: "studentDbDto");
        }
    }
}

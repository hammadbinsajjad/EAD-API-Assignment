using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    public partial class SubjectModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "subjectDbDto",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "subjectDbDto");
        }
    }
}

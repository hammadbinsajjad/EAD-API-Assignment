﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "studentDbDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentDbDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subjectDbDto",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjectDbDto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "studentSubjectDbDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SID = table.Column<int>(type: "INTEGER", nullable: false),
                    studentDbDtoId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectDbDtoid = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    GPA = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentSubjectDbDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentSubjectDbDto_studentDbDto_studentDbDtoId",
                        column: x => x.studentDbDtoId,
                        principalTable: "studentDbDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentSubjectDbDto_subjectDbDto_SubjectDbDtoid",
                        column: x => x.SubjectDbDtoid,
                        principalTable: "subjectDbDto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjectDbDto_studentDbDtoId",
                table: "studentSubjectDbDto",
                column: "studentDbDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjectDbDto_SubjectDbDtoid",
                table: "studentSubjectDbDto",
                column: "SubjectDbDtoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentSubjectDbDto");

            migrationBuilder.DropTable(
                name: "studentDbDto");

            migrationBuilder.DropTable(
                name: "subjectDbDto");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoursePlanner.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherViewModel",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherViewModel", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "CourseViewModel",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseViewModel", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_CourseViewModel_TeacherViewModel_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "TeacherViewModel",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopicViewModel",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeSnippetsLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assignment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicViewModel", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_TopicViewModel_CourseViewModel_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseViewModel",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseViewModel_TeacherId",
                table: "CourseViewModel",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicViewModel_CourseId",
                table: "TopicViewModel",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicViewModel");

            migrationBuilder.DropTable(
                name: "CourseViewModel");

            migrationBuilder.DropTable(
                name: "TeacherViewModel");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicJournalCourseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    SpecialtyCode = table.Column<int>(type: "int", nullable: false),
                    SpecialtyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.SpecialtyCode);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeacherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeacherPatronymic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyCode = table.Column<int>(type: "int", nullable: false),
                    Abbreviature = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupCode);
                    table.ForeignKey(
                        name: "FK_Groups_Specialties_SpecialtyCode",
                        column: x => x.SpecialtyCode,
                        principalTable: "Specialties",
                        principalColumn: "SpecialtyCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyCode = table.Column<int>(type: "int", nullable: false),
                    SemesterNumber = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    HoursCount = table.Column<int>(type: "int", nullable: false),
                    AcademicYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_Plans_Specialties_SpecialtyCode",
                        column: x => x.SpecialtyCode,
                        principalTable: "Specialties",
                        principalColumn: "SpecialtyCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plans_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentIdNumber = table.Column<long>(type: "bigint", nullable: false),
                    StudentSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentPatronymic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentGroupId = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentIdNumber);
                    table.ForeignKey(
                        name: "FK_Students_Groups_CurrentGroupId",
                        column: x => x.CurrentGroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoadLists",
                columns: table => new
                {
                    LoadListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadLists", x => x.LoadListId);
                    table.ForeignKey(
                        name: "FK_LoadLists_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadLists_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "PlanId");
                    table.ForeignKey(
                        name: "FK_LoadLists_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentIdNumber = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DropOutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Students_StudentIdNumber",
                        column: x => x.StudentIdNumber,
                        principalTable: "Students",
                        principalColumn: "StudentIdNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoadListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_Lessons_LoadLists_LoadListId",
                        column: x => x.LoadListId,
                        principalTable: "LoadLists",
                        principalColumn: "LoadListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    MarkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    StudentIdNumber = table.Column<long>(type: "bigint", nullable: false),
                    Attendance = table.Column<bool>(type: "bit", nullable: false),
                    MarkValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.MarkId);
                    table.ForeignKey(
                        name: "FK_Marks_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marks_Students_StudentIdNumber",
                        column: x => x.StudentIdNumber,
                        principalTable: "Students",
                        principalColumn: "StudentIdNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StudentIdNumber",
                table: "Appointments",
                column: "StudentIdNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialtyCode",
                table: "Groups",
                column: "SpecialtyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LoadListId",
                table: "Lessons",
                column: "LoadListId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadLists_GroupId",
                table: "LoadLists",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadLists_PlanId",
                table: "LoadLists",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadLists_TeacherId",
                table: "LoadLists",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_LessonId",
                table: "Marks",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_StudentIdNumber",
                table: "Marks",
                column: "StudentIdNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_SpecialtyCode",
                table: "Plans",
                column: "SpecialtyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_SubjectId",
                table: "Plans",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CurrentGroupId",
                table: "Students",
                column: "CurrentGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "LoadLists");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}

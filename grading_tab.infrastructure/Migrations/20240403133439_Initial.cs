using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace grading_tab.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "assessment_type",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "meeting_type",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meeting_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameSuffix = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "section",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_section", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "term",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_term", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_student_person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "dbo",
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_section_SectionId",
                        column: x => x.SectionId,
                        principalSchema: "dbo",
                        principalTable: "section",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "subject_load",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject_load", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subject_load_person_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "dbo",
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subject_load_section_SectionId",
                        column: x => x.SectionId,
                        principalSchema: "dbo",
                        principalTable: "section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subject_load_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "dbo",
                        principalTable: "subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assessment_result",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssessmentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_assessment_result_assessment_type_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "dbo",
                        principalTable: "assessment_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assessment_result_student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "dbo",
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assessment_result_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "dbo",
                        principalTable: "subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assessment_result_term_TermId",
                        column: x => x.TermId,
                        principalSchema: "dbo",
                        principalTable: "term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meeting",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    SubjectLoadId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_meeting_meeting_type_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "dbo",
                        principalTable: "meeting_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_meeting_subject_load_SubjectLoadId",
                        column: x => x.SubjectLoadId,
                        principalSchema: "dbo",
                        principalTable: "subject_load",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "assessment_type",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Attendance" },
                    { 2, "Participation" },
                    { 3, "Assignment" },
                    { 4, "Project - Completion" },
                    { 5, "Project - Delivery" },
                    { 6, "Major Exam" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "meeting_type",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ASYNCHRONOUS" },
                    { 2, "ON-SITE" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "subject",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CE ELECTIVE 2" },
                    { 2, "IT ELECTIVE 3" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "term",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "PRELIM" },
                    { 2, "MIDTERM" },
                    { 3, "PRE-FINAL" },
                    { 4, "FINAL" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_assessment_result_StudentId",
                schema: "dbo",
                table: "assessment_result",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_result_SubjectId",
                schema: "dbo",
                table: "assessment_result",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_result_TermId",
                schema: "dbo",
                table: "assessment_result",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_result_TypeId",
                schema: "dbo",
                table: "assessment_result",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_meeting_SubjectLoadId",
                schema: "dbo",
                table: "meeting",
                column: "SubjectLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_meeting_TypeId",
                schema: "dbo",
                table: "meeting",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_meeting_type_Name",
                schema: "dbo",
                table: "meeting_type",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_student_PersonId",
                schema: "dbo",
                table: "student",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_student_SectionId",
                schema: "dbo",
                table: "student",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_subject_Name",
                schema: "dbo",
                table: "subject",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_subject_load_FacultyId",
                schema: "dbo",
                table: "subject_load",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_subject_load_SectionId",
                schema: "dbo",
                table: "subject_load",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_subject_load_SubjectId",
                schema: "dbo",
                table: "subject_load",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assessment_result",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "meeting",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "assessment_type",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "student",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "term",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "meeting_type",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "subject_load",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "person",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "section",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "subject",
                schema: "dbo");
        }
    }
}

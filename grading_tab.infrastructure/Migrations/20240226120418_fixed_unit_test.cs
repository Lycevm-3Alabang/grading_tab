using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace grading_tab.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixed_unit_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_section_SectionId",
                schema: "dbo",
                table: "person");

            migrationBuilder.DropForeignKey(
                name: "FK_subject_load_person_FacultyId",
                schema: "dbo",
                table: "subject_load");

            migrationBuilder.DropForeignKey(
                name: "FK_subject_load_section_SectionId",
                schema: "dbo",
                table: "subject_load");

            migrationBuilder.DropForeignKey(
                name: "FK_subject_load_subject_SubjectId",
                schema: "dbo",
                table: "subject_load");

            migrationBuilder.DropIndex(
                name: "IX_person_Number",
                schema: "dbo",
                table: "person");

            migrationBuilder.DropIndex(
                name: "IX_person_SectionId",
                schema: "dbo",
                table: "person");

            migrationBuilder.DropColumn(
                name: "Number",
                schema: "dbo",
                table: "person");

            migrationBuilder.DropColumn(
                name: "SectionId",
                schema: "dbo",
                table: "person");

            migrationBuilder.CreateTable(
                name: "student",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_student_person_PersonId1",
                        column: x => x.PersonId1,
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

            migrationBuilder.CreateIndex(
                name: "IX_student_PersonId",
                schema: "dbo",
                table: "student",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_student_PersonId1",
                schema: "dbo",
                table: "student",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_student_SectionId",
                schema: "dbo",
                table: "student",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_subject_load_person_FacultyId",
                schema: "dbo",
                table: "subject_load",
                column: "FacultyId",
                principalSchema: "dbo",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subject_load_section_SectionId",
                schema: "dbo",
                table: "subject_load",
                column: "SectionId",
                principalSchema: "dbo",
                principalTable: "section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subject_load_subject_SubjectId",
                schema: "dbo",
                table: "subject_load",
                column: "SubjectId",
                principalSchema: "dbo",
                principalTable: "subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subject_load_person_FacultyId",
                schema: "dbo",
                table: "subject_load");

            migrationBuilder.DropForeignKey(
                name: "FK_subject_load_section_SectionId",
                schema: "dbo",
                table: "subject_load");

            migrationBuilder.DropForeignKey(
                name: "FK_subject_load_subject_SubjectId",
                schema: "dbo",
                table: "subject_load");

            migrationBuilder.DropTable(
                name: "student",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "assessment_type",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "assessment_type",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "assessment_type",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "assessment_type",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "assessment_type",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "assessment_type",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                schema: "dbo",
                table: "person",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SectionId",
                schema: "dbo",
                table: "person",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_person_Number",
                schema: "dbo",
                table: "person",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_person_SectionId",
                schema: "dbo",
                table: "person",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_person_section_SectionId",
                schema: "dbo",
                table: "person",
                column: "SectionId",
                principalSchema: "dbo",
                principalTable: "section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subject_load_person_FacultyId",
                schema: "dbo",
                table: "subject_load",
                column: "FacultyId",
                principalSchema: "dbo",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subject_load_section_SectionId",
                schema: "dbo",
                table: "subject_load",
                column: "SectionId",
                principalSchema: "dbo",
                principalTable: "section",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_subject_load_subject_SubjectId",
                schema: "dbo",
                table: "subject_load",
                column: "SubjectId",
                principalSchema: "dbo",
                principalTable: "subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

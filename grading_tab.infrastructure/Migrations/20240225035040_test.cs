using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace grading_tab.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

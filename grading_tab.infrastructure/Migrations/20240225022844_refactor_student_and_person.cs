using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace grading_tab.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactor_student_and_person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_section_SectionId",
                schema: "dbo",
                table: "person");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student",
                schema: "dbo");

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
        }
    }
}

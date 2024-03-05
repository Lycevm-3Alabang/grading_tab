using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace grading_tab.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixed_person_student_configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assessment_result_person_StudentId",
                schema: "dbo",
                table: "assessment_result");

            migrationBuilder.DropForeignKey(
                name: "FK_student_person_PersonId",
                schema: "dbo",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_student_person_PersonId1",
                schema: "dbo",
                table: "student");

            migrationBuilder.DropIndex(
                name: "IX_student_PersonId1",
                schema: "dbo",
                table: "student");

            migrationBuilder.DropColumn(
                name: "PersonId1",
                schema: "dbo",
                table: "student");

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_result_student_StudentId",
                schema: "dbo",
                table: "assessment_result",
                column: "StudentId",
                principalSchema: "dbo",
                principalTable: "student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_person_PersonId",
                schema: "dbo",
                table: "student",
                column: "PersonId",
                principalSchema: "dbo",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assessment_result_student_StudentId",
                schema: "dbo",
                table: "assessment_result");

            migrationBuilder.DropForeignKey(
                name: "FK_student_person_PersonId",
                schema: "dbo",
                table: "student");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId1",
                schema: "dbo",
                table: "student",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_student_PersonId1",
                schema: "dbo",
                table: "student",
                column: "PersonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_result_person_StudentId",
                schema: "dbo",
                table: "assessment_result",
                column: "StudentId",
                principalSchema: "dbo",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_person_PersonId",
                schema: "dbo",
                table: "student",
                column: "PersonId",
                principalSchema: "dbo",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_student_person_PersonId1",
                schema: "dbo",
                table: "student",
                column: "PersonId1",
                principalSchema: "dbo",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

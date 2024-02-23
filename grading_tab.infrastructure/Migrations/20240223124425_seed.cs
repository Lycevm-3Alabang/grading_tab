using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace grading_tab.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assessment_result_Term_TermId",
                schema: "dbo",
                table: "assessment_result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Term",
                table: "Term");

            migrationBuilder.RenameTable(
                name: "Term",
                newName: "term",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_term",
                schema: "dbo",
                table: "term",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_result_term_TermId",
                schema: "dbo",
                table: "assessment_result",
                column: "TermId",
                principalSchema: "dbo",
                principalTable: "term",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assessment_result_term_TermId",
                schema: "dbo",
                table: "assessment_result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_term",
                schema: "dbo",
                table: "term");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "meeting_type",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "meeting_type",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "subject",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "subject",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "term",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "term",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "term",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "term",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "term",
                schema: "dbo",
                newName: "Term");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Term",
                table: "Term",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_result_Term_TermId",
                schema: "dbo",
                table: "assessment_result",
                column: "TermId",
                principalTable: "Term",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace grading_tab.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class added_assessment_type_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace grading_tab.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updated_person_ctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameSuffix",
                schema: "dbo",
                table: "person",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameSuffix",
                schema: "dbo",
                table: "person");
        }
    }
}

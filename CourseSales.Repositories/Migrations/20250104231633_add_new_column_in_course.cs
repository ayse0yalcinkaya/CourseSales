using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseSales.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class add_new_column_in_course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Courses");
        }
    }
}

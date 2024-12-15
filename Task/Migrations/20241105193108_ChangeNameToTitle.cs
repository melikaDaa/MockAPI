using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasks1.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameToTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Categories",
                newName: "Name");
        }
    }
}

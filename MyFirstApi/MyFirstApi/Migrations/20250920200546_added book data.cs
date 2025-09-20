using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyFirstApi.Migrations
{
    /// <inheritdoc />
    public partial class addedbookdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Title", "YearPublished" },
                values: new object[,]
                {
                    { 1, "Andrew Hunt & David Thomas", "The Pragmatic Programmer", 1999 },
                    { 2, "Robert C. Martin", "Clean Code", 2008 },
                    { 3, "Erich Gamma et al.", "Design Patterns", 1994 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud_Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatasForLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Code", "Icon", "Name" },
                values: new object[] { "az", "https://cdn-icons-png.flaticon.com/512/630/630657.png", "Azerbaycan" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Code",
                keyValue: "az");
        }
    }
}

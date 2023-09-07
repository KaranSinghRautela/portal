using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace portal.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bfc7d24-9841-4fdb-8dec-6211ca17882e", "3", "HR", "HR" },
                    { "38a6eb37-d77d-4b78-b220-7662ddaa2ad0", "2", "User", "User" },
                    { "617ce4ef-6509-468d-8d55-26302f1bd91c", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bfc7d24-9841-4fdb-8dec-6211ca17882e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38a6eb37-d77d-4b78-b220-7662ddaa2ad0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "617ce4ef-6509-468d-8d55-26302f1bd91c");
        }
    }
}

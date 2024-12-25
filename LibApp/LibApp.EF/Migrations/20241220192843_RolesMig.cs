using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibApp.EF.Migrations
{
    /// <inheritdoc />
    public partial class RolesMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1796eb35-0e18-44d6-aa2c-bd869f5914b4", "ec20fefd-93d7-418e-ab9c-c7eb77966e2f", "Admin", "admin" },
                    { "25c456d4-fd4d-44a3-8ebb-dc2b83c6a145", "cfa1ba63-dd59-48a8-b0d8-739c3e823d9d", "NormalUser", "normaluser" },
                    { "8ac7778a-39ce-45b9-8d05-4659b0c66cfa", "ba6b8317-52e0-4767-ba27-8c9e1af8f507", "Reader", "reader" },
                    { "9f953337-b00f-473d-9e72-9a8deffbfb5d", "974f2e9a-4bab-449c-a9ed-7164d9d13626", "SuperAdmin", "superadmin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1796eb35-0e18-44d6-aa2c-bd869f5914b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25c456d4-fd4d-44a3-8ebb-dc2b83c6a145");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ac7778a-39ce-45b9-8d05-4659b0c66cfa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f953337-b00f-473d-9e72-9a8deffbfb5d");
        }
    }
}

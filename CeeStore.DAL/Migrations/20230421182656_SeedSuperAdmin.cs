using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeeStore.DAL.Migrations
{
    public partial class SeedSuperAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fbc3e00-a603-4a12-85c6-46aee57f5a4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1feb4373-bac1-426e-bcb1-172a74486496");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1e231e8-90df-4223-ad7f-b7e9bddc1916");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0dfffbba-7922-4cb4-9a52-88968318a290", "0dff019b-dcc6-4ed5-afcf-7fbe404cef9e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e2b67b5-3c58-4638-8dd9-e710cc3c9d3a", "4579c4ea-ed58-4491-bcc2-06de912cd6b4", "Buyer", "BUYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4a005127-602f-4ec1-b078-796876660701", "ef7357d5-b028-41be-bf9a-10c8fef60e4f", "Seller", "SELLER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dfffbba-7922-4cb4-9a52-88968318a290");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e2b67b5-3c58-4638-8dd9-e710cc3c9d3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a005127-602f-4ec1-b078-796876660701");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1fbc3e00-a603-4a12-85c6-46aee57f5a4b", "d2d01c0b-28d9-46f6-ba06-151bd418e34d", "Buyer", "BUYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1feb4373-bac1-426e-bcb1-172a74486496", "47e82bbe-8ee5-4b7e-934b-89ebd2c78a61", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1e231e8-90df-4223-ad7f-b7e9bddc1916", "0ecfa5d0-385e-4432-bd06-647d518a4b97", "Admin", "ADMIN" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeeStore.DAL.Migrations
{
    public partial class AddOrderandCartEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6d03de8-bf1a-4362-9768-121477b26be0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8be6a89-91dd-4d87-95e5-d85b96680d84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc03db77-3c95-4905-997a-35a6ae896e03");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "128c69c0-bd9d-4209-958b-7fa1f10f6f6f", "724014f1-bd16-4d63-a5be-e4fc9a7f38c1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15f2c445-ccc2-4b99-9704-a7e657ac9745", "72ebe02a-d57a-434a-aa54-51cb3ac7cddb", "Buyer", "BUYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36c85554-191d-4117-94c2-d45b25a341cd", "e9107d18-8fb6-4ef3-a023-325b67a1fe11", "Seller", "SELLER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "128c69c0-bd9d-4209-958b-7fa1f10f6f6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15f2c445-ccc2-4b99-9704-a7e657ac9745");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36c85554-191d-4117-94c2-d45b25a341cd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6d03de8-bf1a-4362-9768-121477b26be0", "70e31c11-e876-4869-b2bc-77abf8511dfd", "Buyer", "BUYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8be6a89-91dd-4d87-95e5-d85b96680d84", "cd355daa-de70-4a84-a611-1e602b62f603", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc03db77-3c95-4905-997a-35a6ae896e03", "8e8dfb53-0416-4be6-aa4d-4162d8c6a24f", "Admin", "ADMIN" });
        }
    }
}

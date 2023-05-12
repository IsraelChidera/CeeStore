using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeeStore.DAL.Migrations
{
    public partial class EditProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08bf0482-12d7-40c6-9c0a-a64528417d0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d481f9d5-d229-4eb2-9609-25b1a1769296");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5cdac05-84b5-4616-a8a0-a497d33f72e0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e9d7c60-827b-4022-a7c8-98cb86df1ffc", "bcee1410-2413-41bc-ac52-8fb5d0a53e77", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b348b6ba-49e5-4588-aeb2-5cf92fc42d47", "f1c26fcc-fdf1-43e7-ae1e-e0c1a4a47ca9", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e372e06e-1985-4e64-b83c-0b1e43bea943", "212a3b94-d9d1-406d-8114-979b954b2137", "Buyer", "BUYER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e9d7c60-827b-4022-a7c8-98cb86df1ffc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b348b6ba-49e5-4588-aeb2-5cf92fc42d47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e372e06e-1985-4e64-b83c-0b1e43bea943");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08bf0482-12d7-40c6-9c0a-a64528417d0e", "7ff7395e-ee0d-41a2-b547-e768eb62b415", "Buyer", "BUYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d481f9d5-d229-4eb2-9609-25b1a1769296", "c37d254a-0120-49e0-aa4f-7345530f7ed6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5cdac05-84b5-4616-a8a0-a497d33f72e0", "3b22a0e0-3b8b-4257-b23d-adb4e25c3692", "Seller", "SELLER" });
        }
    }
}

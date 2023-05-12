using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeeStore.DAL.Migrations
{
    public partial class UpdatedProductEntities0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a40a24a-a70f-49f1-9fd5-7655fbd315b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "291a05a0-4e37-49c8-957e-9a10038e6f5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cce597c1-b09d-4422-a792-f8de4ac61d0f");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "1a40a24a-a70f-49f1-9fd5-7655fbd315b3", "1a1db831-6b5e-47d9-af6e-98e053bda900", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "291a05a0-4e37-49c8-957e-9a10038e6f5f", "238e3467-4daa-4aa2-9229-bf85f8ad8a31", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cce597c1-b09d-4422-a792-f8de4ac61d0f", "1aea947f-62a8-4980-b9de-85cab7ebcf15", "Buyer", "BUYER" });
        }
    }
}

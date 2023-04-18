using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeeStore.DAL.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c80d880-3bb0-4e73-a1b9-7ed22f9a61be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56f04334-ec7a-45ec-a239-083c047cfba8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0fbc3ba-5632-428f-8d2d-c8cf39883071");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "307cfb90-cc35-4444-accb-5b53a6b47212", "78f6432b-9c76-4bd1-8c1f-b1c4a46de6d1", "Buyer", "BUYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6bb44f75-3e75-406b-9202-5621c89ba22c", "2b3766e4-d292-4c8e-aba5-2a628c51b291", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b395e355-79f4-473e-8084-51b7cf97d0f3", "34ebca49-7794-4d1b-a0cc-c3843ba8cf36", "Seller", "SELLER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "307cfb90-cc35-4444-accb-5b53a6b47212");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bb44f75-3e75-406b-9202-5621c89ba22c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b395e355-79f4-473e-8084-51b7cf97d0f3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c80d880-3bb0-4e73-a1b9-7ed22f9a61be", "d30d45ce-044a-4b73-8ad2-66a0553cd78f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56f04334-ec7a-45ec-a239-083c047cfba8", "78f6ea3c-4e0b-41be-b012-496c0ff3e29d", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0fbc3ba-5632-428f-8d2d-c8cf39883071", "dbfba4bd-d958-4a14-b617-72cdfe2dd666", "Buyer", "BUYER" });
        }
    }
}

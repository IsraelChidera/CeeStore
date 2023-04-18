using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeeStore.DAL.Migrations
{
    public partial class FixingBugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cea1630-a7a6-40c8-a0ca-fe8024c9915f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d6d1eb6-f31a-468f-a357-d8d840cdbde0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80cc01c0-9c2c-4ee3-9f7e-7b1183a57a1e");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

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
                values: new object[] { "6cea1630-a7a6-40c8-a0ca-fe8024c9915f", "a01ea5fb-f739-4f69-8256-00c285df4143", "Buyer", "BUYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d6d1eb6-f31a-468f-a357-d8d840cdbde0", "8f714d86-3ca4-49c8-bce4-5704c251ea92", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80cc01c0-9c2c-4ee3-9f7e-7b1183a57a1e", "af55b2de-bf3d-4b81-b61b-8ded7c536cf2", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

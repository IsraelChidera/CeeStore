using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeeStore.DAL.Migrations
{
    public partial class FixOrdersForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "4f107ed3-e2bd-40f9-ac50-c7705bbbec26", "6c5ca9e4-2a1b-4103-b754-12211c44b417", "Buyer", "BUYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "938c656e-8383-4626-8645-703652249755", "c49d9c59-5e7c-4881-a486-194bfee0ab73", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7658fff-cd75-4954-9d95-ac9878f0177b", "730bf636-2694-40bf-81ea-b4d464134369", "Seller", "SELLER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f107ed3-e2bd-40f9-ac50-c7705bbbec26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "938c656e-8383-4626-8645-703652249755");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7658fff-cd75-4954-9d95-ac9878f0177b");

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
    }
}

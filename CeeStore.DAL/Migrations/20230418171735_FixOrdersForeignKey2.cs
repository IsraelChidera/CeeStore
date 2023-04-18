using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeeStore.DAL.Migrations
{
    public partial class FixOrdersForeignKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "7f91cf93-c007-4d8d-bff1-9af5b7e15462", "23e4fc2e-6ac7-40fd-ad3c-1e264d7d680f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8681e6d0-2f53-4645-b0ef-0681f70961c0", "34b0104c-d81c-46b7-be29-31ddcc08f6ac", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7c024fd-70f2-4d04-b2b1-c9850f8f4c66", "661574c4-cd91-47ee-a3b9-4fb589f1db62", "Buyer", "BUYER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f91cf93-c007-4d8d-bff1-9af5b7e15462");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8681e6d0-2f53-4645-b0ef-0681f70961c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7c024fd-70f2-4d04-b2b1-c9850f8f4c66");

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
    }
}

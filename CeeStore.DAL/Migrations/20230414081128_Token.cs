using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeeStore.DAL.Migrations
{
    public partial class Token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae983db1-1a99-4e3f-8f3a-71a1041046a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc349b8f-197a-42f3-8511-d1e5e744c894");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c062a513-a9fb-4e7f-9dd0-98b4a16b00f5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c727d6f-27b3-4173-891c-6eecf03d199c", "bfd680c4-2769-49bf-842c-f4e2d12d711a", "Buyer", "BUYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a37965ca-6b00-45e1-a3ea-dfe64986dfe4", "46863e34-2cee-47a1-b0e8-f914f0a772fd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7427dbd-6db0-40c8-a1ba-c19efb43b237", "bdfbb832-85e0-44bb-b518-f25ff688f522", "Seller", "SELLER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c727d6f-27b3-4173-891c-6eecf03d199c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a37965ca-6b00-45e1-a3ea-dfe64986dfe4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7427dbd-6db0-40c8-a1ba-c19efb43b237");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae983db1-1a99-4e3f-8f3a-71a1041046a5", "fa1a24de-4894-4101-916d-ccd0459368bb", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bc349b8f-197a-42f3-8511-d1e5e744c894", "bc47e245-03e6-4e12-a410-45ab7c859202", "Buyer", "BUYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c062a513-a9fb-4e7f-9dd0-98b4a16b00f5", "da7f7273-8e90-45eb-bc5a-176fc881e84f", "Admin", "ADMIN" });
        }
    }
}

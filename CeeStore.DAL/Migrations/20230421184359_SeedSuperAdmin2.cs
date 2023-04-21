using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeeStore.DAL.Migrations
{
    public partial class SeedSuperAdmin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "aecf81f8-ac9d-4093-b592-970d1ffce8d1", "f0427434-dd7a-470f-ba9a-9f9de50be57b", "Buyer", "BUYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d844d1a4-d734-46de-a4fe-3ce244a37602", "d1903b9a-98ba-4b29-80fa-e290eea5385a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea304336-f15e-4e1a-8d24-db2fbe574318", "3f45aa8e-ff6b-4b24-9286-c7b8e6a04c15", "Seller", "SELLER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aecf81f8-ac9d-4093-b592-970d1ffce8d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d844d1a4-d734-46de-a4fe-3ce244a37602");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea304336-f15e-4e1a-8d24-db2fbe574318");

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
    }
}

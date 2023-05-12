using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeeStore.DAL.Migrations
{
    public partial class UpdatedProductEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d62c1251-c119-41bf-9801-6312a5116e16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6440e2c-28d6-4dda-9eaf-1f52d85a8ee4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb8a4853-0a03-440f-ae5f-de03fa857817");

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d62c1251-c119-41bf-9801-6312a5116e16", "8a4bdfe5-1ed1-4a08-837c-289407af97fc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6440e2c-28d6-4dda-9eaf-1f52d85a8ee4", "ddf69937-3972-4816-92ab-26dd4a0f65d5", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb8a4853-0a03-440f-ae5f-de03fa857817", "fdad1ca0-b7b1-4cd6-a3fa-a996bca69623", "Buyer", "BUYER" });
        }
    }
}

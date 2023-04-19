using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeeStore.DAL.Migrations
{
    public partial class FixOrdersForeignKey4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c095021-0d5d-4681-9515-67d394dcb003");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44f62b52-5bad-4248-a82c-f08f56628695");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c71a2a76-27b6-457d-852e-dfe7ae87494c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "77847992-7d88-4b44-b168-b2ec2c8b2b9d", "3917830c-683b-406f-8ebc-72d06a95a8d2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7da55322-9b85-433d-92bd-e1793794d5fc", "ecfcb0f2-5b5d-46ab-8c5f-79042da3b61d", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad17380c-56bb-4e2a-beba-19c4d6e4c768", "660c86e1-2f3e-454e-8f3e-8ae8dfe68d7b", "Buyer", "BUYER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77847992-7d88-4b44-b168-b2ec2c8b2b9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7da55322-9b85-433d-92bd-e1793794d5fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad17380c-56bb-4e2a-beba-19c4d6e4c768");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c095021-0d5d-4681-9515-67d394dcb003", "2eaea74e-d051-45d7-95fa-f04193276263", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44f62b52-5bad-4248-a82c-f08f56628695", "ffa1620e-efb8-4a43-9565-fe2acfb0cfd7", "Buyer", "BUYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c71a2a76-27b6-457d-852e-dfe7ae87494c", "51c6239f-b953-411f-b30e-9d5c79e6d7b2", "Admin", "ADMIN" });
        }
    }
}

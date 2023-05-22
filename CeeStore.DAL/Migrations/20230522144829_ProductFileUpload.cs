using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeeStore.DAL.Migrations
{
    public partial class ProductFileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallbackUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentGateway = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    shippingmethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstimateDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrdersId);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Order",
                        principalColumn: "OrdersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35ca7534-83e0-4bae-8307-ea4be45984b7", "fcd76efd-24ae-4d8c-9ddf-abd13586a9fa", "Buyer", "BUYER" },
                    { "35e7a0b6-7a90-45b2-9c2f-271817ffe42f", "13e7ac1c-0e9c-4e33-ad7c-d238b4088dfe", "Admin", "ADMIN" },
                    { "acef6776-83d4-425b-aabc-fc32e1fc2075", "03e8f342-0c3a-4e91-84d1-498e34cda185", "Seller", "SELLER" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandName", "Description", "Price", "ProductImage", "ProductName", "Quantity", "UserId", "UserId1" },
                values: new object[,]
                {
                    { new Guid("162d1534-8a65-44c8-89df-2c0730864f2b"), "Absolut", "Absolut Vodka Vanilla 1L", 6000m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-4.jpg", "Absolut Vodka", 5, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("1d845433-2784-4ddb-be79-39e17377136c"), "Nivea", "NIVEA Perfect & Radiant 3 In 1 Face Cleanser For Women - 150ml", 15000m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749329/samples/ecommerce/leather-bag-gray.jpg", "Nivea Perfect & Radiant", 10, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("2cdeb67f-3abb-45ad-9453-a6f441200646"), "Jameson Black", "Jameson Black Barrel 7", 16085m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749330/samples/ecommerce/accessories-bag.jpg", "Jameson Black", 10, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("406b788c-b52f-4553-8f27-97a547045841"), "Jameson", "Jameson Irish Whiskey", 10500m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-4.jpg", "Jameson Whiskey", 10, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("44b7062d-7ba5-4f9e-8e17-a55dc88299cb"), "Coca-cola", "Coca-cola Drink - 50cl P", 1900m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749330/samples/ecommerce/accessories-bag.jpg", "Coca-cola", 10, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("5987f77d-3ddc-4a9e-b1e4-2d79e986da83"), "DII255", "Dry Electric Iron - DII255", 5800m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749330/samples/ecommerce/accessories-bag.jpg", "Electric Iron", 10, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("68ba7ee0-5e59-46e0-a524-496a68bb0b09"), "Monster", "Monster Can Green 44cl", 11000m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-4.jpg", "Monster drink", 14, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("6eae2eab-7367-4eb6-af47-7932690e577c"), "Nike", "White Air Jordan II", 55500m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-5.jpg", "Air Jordan II", 10, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("7a0aaaea-d2ba-4cc1-86dd-f01c5343c91d"), "Maltina", "Maltina Classic Can 33CL", 5400m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-4.jpg", "Maltina Classic", 24, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("835bb68d-9e09-4b81-b1ed-3925a1db68af"), "Glover Sport Wears", "Red Arsenal T-shirt of all sizes (S,M,L,Xl,XXL)", 8500m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-5.jpg", "Arsenal T-shirt", 8, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("91c22eb3-8e1c-4a39-bd5f-299dcad5c4c1"), "Xivex Wears", "Multi-colored vintage wears", 12500m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-5.jpg", "Vintage wears", 10, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("b56c5e4c-9307-47af-9ebe-3d4161705cba"), "Xcrux", "Legends are born in March premium class T-shirt", 5000m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749330/samples/ecommerce/accessories-bag.jpg", "Plain Tshirt", 10, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"), "X-G", "Black winter hoodies (S,M,L,Xl,XXL)", 14500m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749326/samples/people/boy-snow-hoodie.jpg", "Spring Hoodie", 5, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("db2f4e29-9e36-4cc9-855c-176ff930c37a"), "Harpic", "Harpic Toilet Cleaner: M", 1800m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-4.jpg", "Harpic Cleaner", 14, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("db3b7be1-37a3-40d3-b363-5ae91cf7b47c"), "New Balance", "White soled, high new balance", 15000m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-5.jpg", "New balance sneakers", 10, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null },
                    { new Guid("ee67a92c-a8e2-44a1-8e50-14a59d718f84"), "Grey Tshirt Store", "Loius Vuitton Beenie (red, yellow, black)", 6500m, "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749329/samples/ecommerce/leather-bag-gray.jpg", "Plain Men's T-shirts Combo of 3", 10, new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId1",
                table: "Carts",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId1",
                table: "Order",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrdersId",
                table: "OrderItem",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId1",
                table: "Products",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

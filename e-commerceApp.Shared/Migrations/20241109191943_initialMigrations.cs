using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerceApp.Shared.Migrations
{
    public partial class initialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartegoryId = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_CartegoryId",
                        column: x => x.CartegoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Carts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "d20a0f9e-6ab6-4446-88ec-cf7a29b6dc66", "Admin", "ADMIN" },
                    { 2, "a8ee783b-ed5e-4bab-bb3d-6313b171b287", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { 1, 0, null, "3ef80918-4867-4251-be28-ad8a8c4fe2f3", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8586), "john.doe@example.com", false, "John", "Doe", false, null, null, null, null, "123456-7890", false, null, false, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8587), "john.doe@example.com" },
                    { 2, 0, null, "8f6b22f1-bfb9-461f-9495-6bdbf197495c", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8594), "jane.smith@example.com", false, "Jane", "Smith", false, null, null, null, null, "9876543210", false, null, false, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8595), "jane.smith@example.com" },
                    { 3, 0, null, "cad4c1e9-f942-4437-bb0b-4c99d6d87bd3", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8602), "ike.sunny@example.com", false, "Ike", "Sunny", false, null, null, null, null, "4567891234", false, null, false, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8602), "ike.sunny@example.com" },
                    { 4, 0, null, "8c09a224-7108-41b8-b370-31d3808169a2", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8609), "adam.jane@example.com", false, "Adam", "Jane", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8609), "adam.jane@example.com" },
                    { 5, 0, null, "b2eca805-1b2e-4173-b8d5-d1712aba6ad2", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8619), "ronald.smith@example.com", false, "Ronald", "Smith", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8620), "ronald.smith@example.com" },
                    { 6, 0, null, "e02068f5-2d44-446b-bd2f-556ee62b754d", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8633), "gate.paulo@example.com", false, "Gate", "Paulo", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8634), "gate.paulo@example.com" },
                    { 7, 0, null, "66634919-89b8-4a27-8bcc-f1ca14390fdf", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8641), "lurge.luck@example.com", false, "Lurge", "Luck", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8641), "lurge.luck@example.com" },
                    { 8, 0, null, "bc3798d4-90f2-46dc-a9f8-c4d0cdaa04a6", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8648), "bana.good@example.com", false, "Bana", "Good", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8648), "bana.good@example.com" },
                    { 9, 0, null, "eeb8fddc-047e-4c77-ac6b-131aa06f3512", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8655), "matt.paul@example.com", false, "Matt", "Paul", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8656), "matt.paul@example.com" },
                    { 10, 0, null, "cd44c010-c4d6-4cb2-940c-c8a0862b64e2", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8662), "john.matt@example.com", false, "John", "Matt", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8663), "john.matt@example.com" },
                    { 11, 0, null, "4e487863-6a74-4f02-bbb4-871063aa6ab1", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8888), "joan.mark@example.com", false, "Joan", "Mark", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(8889), "joan.mark@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CreatedDate", "CustomerId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 30, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9508), 1 },
                    { 2, new DateTime(2024, 11, 1, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9510), 2 },
                    { 3, new DateTime(2024, 11, 4, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9511), 3 },
                    { 4, new DateTime(2024, 11, 6, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9512), 4 },
                    { 5, new DateTime(2024, 11, 7, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9513), 5 },
                    { 6, new DateTime(2024, 11, 4, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9514), 6 },
                    { 7, new DateTime(2024, 10, 27, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9515), 7 },
                    { 8, new DateTime(2024, 10, 28, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9516), 8 },
                    { 9, new DateTime(2024, 11, 5, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9518), 9 },
                    { 10, new DateTime(2024, 10, 17, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9519), 10 },
                    { 11, new DateTime(2024, 11, 5, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9520), 11 }
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Phone" },
                    { 2, "Laptop" },
                    { 3, "Charger" },
                    { 4, "Earpiece" },
                    { 5, "Tablet" },
                    { 6, "Headphones" },
                    { 7, "Smartwatch" },
                    { 8, "Accessories" },
                    { 9, "Gaming" },
                    { 10, "Fashion" },
                    { 11, "Home Appliances" }
                });

            migrationBuilder.InsertData(
                table: "OrderHeaders",
                columns: new[] { "Id", "Carrier", "City", "Name", "OrderDate", "OrderStatus", "PaymentDate", "PaymentDueDate", "PaymentIntentId", "PaymentStatus", "PhoneNumber", "PostalCode", "SessionId", "ShippingDate", "State", "StreetAddress", "TotalPrice", "TrackingNumber", "UnitPrice", "UserId" },
                values: new object[,]
                {
                    { 1, null, "City A", "John Doe", new DateTime(2024, 10, 30, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9078), "Shipped", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paid", "1234567890", "12345", null, new DateTime(2024, 11, 4, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9090), "Agege", "123 Main St", 9999m, null, 0m, 1 },
                    { 2, null, "City B", "Jane Sunny", new DateTime(2024, 11, 1, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9094), "Delivered", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UnPaid", "98789943210", "67890", null, new DateTime(2024, 11, 5, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9094), "Ajah", "86 Oak St", 19999m, null, 0m, 2 },
                    { 3, null, "City C", "James Wis", new DateTime(2024, 10, 31, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9098), "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paid", "9867843210", "77898", null, new DateTime(2024, 10, 31, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9099), " Makurdi", "45 Oak St", 70000m, null, 0m, 3 },
                    { 4, null, "City D", "Joan Mark", new DateTime(2024, 11, 3, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9101), "Delivered", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refunded", "9876543210", "78754", null, new DateTime(2024, 11, 5, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9102), "State A", "956 Oak St", 60000m, null, 0m, 4 },
                    { 5, null, "City E", "John Matt", new DateTime(2024, 11, 8, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9103), "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paid", "9876887210", "99654", null, new DateTime(2024, 11, 1, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9104), "State Polaris", "496 Oak St", 87000m, null, 0m, 5 },
                    { 6, null, "City F", "Matt Paul", new DateTime(2024, 10, 28, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9106), "Pending", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refunded", "4878743210", "09908", null, new DateTime(2024, 11, 5, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9107), "State New", "76 Oak St", 76000m, null, 0m, 6 },
                    { 7, null, "City G", "Bana Good", new DateTime(2024, 11, 1, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9109), "Cancelled", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paid", "9898743210", "88978", null, new DateTime(2024, 11, 2, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9109), "State Paris", "6 Oak St", 30000m, null, 0m, 7 },
                    { 8, null, "City H", "Lurge Luck", new DateTime(2024, 10, 31, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9112), "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refunded", "9874543210", "00986", null, new DateTime(2024, 11, 4, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9112), "State", "86 Oak St", 90000m, null, 0m, 8 },
                    { 9, null, "City I", "Gate Paulo", new DateTime(2024, 10, 26, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9114), "Cancelled", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UnPaid", "9878453210", "00987", null, new DateTime(2024, 10, 26, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9115), "State Mark", "26 Oak St", 98000m, null, 0m, 9 },
                    { 10, null, "City J", "Ronald Smith", new DateTime(2024, 10, 22, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9117), "Pending", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refunded", "6526543210", "77654", null, new DateTime(2024, 10, 17, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9118), "State Town", "956 Oak St", 67000m, null, 0m, 10 },
                    { 11, null, "City K", "Jane Adam", new DateTime(2024, 11, 2, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9120), "Shipped", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paid", "9876920210", "88765", null, new DateTime(2024, 11, 6, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9121), "State V", "16 Oak St", 450000m, null, 0m, 11 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartegoryId", "CreatedDate", "Description", "ImageUrl", "Price", "ProductStatus", "StockQuantity", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9024), "Description of Product 1", "https://example.com/images/product1.jpg", 170000m, 0, 100, "Product 1", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9024) },
                    { 2, 2, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9027), "Description of Product 2", "https://example.com/images/product2.jpg", 295000m, 0, 50, "Product 2", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9028) },
                    { 3, 3, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9030), "Description of Product 3", "https://example.com/images/product3.jpg", 49500m, 2, 40, "Product 3", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9030) },
                    { 4, 4, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9032), "Description of Product 4", "https://example.com/images/product4.jpg", 50000m, 1, 500, "Product 4", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9033) },
                    { 5, 5, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9034), "Description of Product 5", "https://example.com/images/product5.jpg", 900000m, 1, 700, "Product 5", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9034) },
                    { 6, 6, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9036), "Description of Product 6", "https://example.com/images/product6.jpg", 856000m, 1, 900, "Product 6", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9036) },
                    { 7, 7, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9038), "Description of Product 7", "https://example.com/images/product7.jpg", 7000m, 1, 80, "Product 7", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9038) },
                    { 8, 8, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9039), "Description of Product 8", "https://example.com/images/product8.jpg", 25000m, 1, 800, "Product 8", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9040) },
                    { 9, 9, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9042), "Description of Product 9", "https://example.com/images/product9.jpg", 780000m, 1, 700, "Product 9", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9042) },
                    { 10, 10, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9044), "Description of Product 10", "https://example.com/images/product10.jpg", 56000m, 1, 700, "Product 10", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9044) },
                    { 11, 11, new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9046), "Description of Product 11", "https://example.com/images/product11.jpg", 45000m, 1, 600, "Product 11", new DateTime(2024, 11, 9, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9046) }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Count", "OrderHeaderId", "Price", "ProductId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, 1, 1999m, 1, 1 },
                    { 2, 1, 2, 2999m, 2, 2 },
                    { 3, 3, 3, 4999m, 3, 3 },
                    { 4, 5, 4, 4500m, 4, 4 },
                    { 5, 6, 5, 55000m, 5, 5 },
                    { 6, 9, 6, 6700m, 6, 6 },
                    { 7, 3, 7, 8900m, 7, 7 },
                    { 8, 5, 8, 45000m, 8, 8 },
                    { 9, 8, 9, 99000m, 9, 9 },
                    { 10, 7, 10, 8900m, 10, 10 },
                    { 11, 6, 11, 235000m, 11, 11 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CreatedDate", "CustomerId", "ProductId", "Rating" },
                values: new object[,]
                {
                    { 1, "Excellent product!", new DateTime(2024, 10, 30, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9459), 1, 1, 5 },
                    { 2, "Good value for the price.", new DateTime(2024, 11, 1, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9462), 2, 2, 4 },
                    { 3, "Satisfactory, but could be improved.", new DateTime(2024, 11, 4, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9463), 3, 3, 3 },
                    { 4, "Fairly pleased with the quality.", new DateTime(2024, 11, 6, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9465), 4, 4, 1 },
                    { 5, "Fairly pleased with the quality.", new DateTime(2024, 11, 7, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9466), 5, 5, 2 },
                    { 6, "pleased with the quality.", new DateTime(2024, 11, 4, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9468), 6, 6, 4 },
                    { 7, "pleased with the quality.", new DateTime(2024, 10, 27, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9469), 7, 7, 4 },
                    { 8, "Very very pleased with the quality.", new DateTime(2024, 10, 28, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9470), 8, 8, 5 },
                    { 9, "Awesome  quality.", new DateTime(2024, 11, 5, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9471), 9, 9, 5 },
                    { 10, "Not really a great quality.", new DateTime(2024, 10, 17, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9473), 10, 10, 2 },
                    { 11, "Patially pleased with the quality.", new DateTime(2024, 11, 5, 19, 19, 42, 135, DateTimeKind.Utc).AddTicks(9477), 11, 11, 3 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "Amount", "ProductId", "ShoppingCartId" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 1, 2, 2 },
                    { 3, 4, 3, 3 },
                    { 4, 5, 4, 4 },
                    { 5, 3, 5, 5 },
                    { 6, 5, 6, 6 },
                    { 7, 6, 7, 7 },
                    { 8, 6, 8, 8 },
                    { 9, 8, 9, 9 },
                    { 10, 8, 10, 10 },
                    { 11, 5, 11, 11 }
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
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UserId",
                table: "OrderDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_UserId",
                table: "OrderHeaders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CartegoryId",
                table: "Products",
                column: "CartegoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCartId",
                table: "ShoppingCartItems",
                column: "ShoppingCartId");
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
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}

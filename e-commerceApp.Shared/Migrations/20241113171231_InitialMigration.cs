using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerceApp.Shared.Migrations
{
    public partial class InitialMigration : Migration
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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentGuidentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartegoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderHeaderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { "3889503c-4b3a-48c3-a6fe-6edda2754867", "b7b6e5b1-3cd6-4efd-b664-273e63a241e0", "Admin", "ADMIN" },
                    { "e7b4ebce-0e1c-4e4c-b5a8-713d9bca6805", "0ef990bb-498f-412e-8c0a-95767493e7fb", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { "04264620-2dc3-4eae-89d2-b8748a2faa5a", 0, null, "35c1464a-384a-4f06-8e61-098f8afeb1fa", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3356), "ike.sunny@example.com", false, "Ike", true, "Sunny", false, null, null, null, null, "4567891234", false, null, false, new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3357), "ike.sunny@example.com" },
                    { "08f80a89-4e4e-4229-b078-f5848ca8d70d", 0, null, "908bb6c3-5c22-464b-9c00-94e4c9aad3cc", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3369), "ronald.smith@example.com", false, "Ronald", true, "Smith", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3370), "ronald.smith@example.com" },
                    { "2e2cfc00-0b76-4c61-920e-ed6f43778790", 0, null, "0c66032c-f09b-4825-84a1-70fb53c9333c", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3376), "gate.paulo@example.com", false, "Gate", true, "Paulo", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3376), "gate.paulo@example.com" },
                    { "44888132-952a-4b48-8a2e-861610b3ac2e", 0, null, "39e9b0cc-7cd3-488e-84c4-b2a69e57a113", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3363), "adam.jane@example.com", false, "Adam", true, "Jane", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3363), "adam.jane@example.com" },
                    { "7e4e7427-c28b-406e-a016-48b28d074381", 0, null, "4b8e4043-11c6-4ad8-8016-64eb94b977b9", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3342), "john.doe@example.com", false, "John", true, "Doe", false, null, null, null, null, "123456-7890", false, null, false, new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3343), "john.doe@example.com" },
                    { "82e8a82f-489d-4c4b-aa91-1e61d35290a2", 0, null, "79dc86a4-be0f-4509-830a-f31122411fc8", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3404), "john.matt@example.com", false, "John", true, "Matt", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3405), "john.matt@example.com" },
                    { "ae9778f0-d32a-48c5-9e71-3180c710c1bb", 0, null, "8c178494-cc0e-4dd7-9033-4279d82a2fee", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3411), "joan.mark@example.com", false, "Joan", true, "Mark", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3411), "joan.mark@example.com" },
                    { "b9418aad-4285-4d05-b354-709ff1ed64db", 0, null, "57222652-009c-4940-a8b4-1c9e1123175a", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3382), "lurge.luck@example.com", false, "Lurge", true, "Luck", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3382), "lurge.luck@example.com" },
                    { "dc87759f-624b-4744-ad42-941bf5abc596", 0, null, "8331d423-313a-4b65-b0b0-34715ad264bb", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3349), "jane.smith@example.com", false, "Jane", true, "Smith", false, null, null, null, null, "9876543210", false, null, false, new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3350), "jane.smith@example.com" },
                    { "e68dfbda-9052-4bd2-b0a4-7ca76e5bdfb9", 0, null, "d99b1bb4-e648-4c17-87d1-59e70c515d05", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3389), "bana.good@example.com", false, "Bana", true, "Good", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3389), "bana.good@example.com" },
                    { "e7cac291-487f-46b2-a1ab-7ccce946f2d6", 0, null, "570750ae-07c4-4936-a641-e15ac07011a9", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3398), "matt.paul@example.com", false, "Matt", true, "Paul", false, null, null, null, null, "3216549870", false, null, false, new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3398), "matt.paul@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CreatedDate", "Email", "ExpirationDate", "UserId" },
                values: new object[,]
                {
                    { "0234b431-517a-4e0b-9c54-6cdf1ed98394", new DateTime(2024, 10, 21, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4974), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "82e8a82f-489d-4c4b-aa91-1e61d35290a2" },
                    { "1631fcfe-f664-43d2-a3fe-6b28ca3a39e8", new DateTime(2024, 11, 8, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4930), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "04264620-2dc3-4eae-89d2-b8748a2faa5a" },
                    { "3a5ab03f-9a51-435b-965c-b6027efc610a", new DateTime(2024, 10, 31, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4957), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b9418aad-4285-4d05-b354-709ff1ed64db" },
                    { "3c89ecf9-0784-4163-a2b2-8efb6db322d6", new DateTime(2024, 11, 5, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4922), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dc87759f-624b-4744-ad42-941bf5abc596" },
                    { "41e405ba-d11d-42d7-b462-94ec83f95fc8", new DateTime(2024, 11, 9, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4969), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e7cac291-487f-46b2-a1ab-7ccce946f2d6" },
                    { "4de67e63-4d16-424c-9225-94302e48232c", new DateTime(2024, 11, 1, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4963), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e68dfbda-9052-4bd2-b0a4-7ca76e5bdfb9" },
                    { "8e773d84-3a2f-4230-82c0-9ff2af6d118e", new DateTime(2024, 11, 8, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4952), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2e2cfc00-0b76-4c61-920e-ed6f43778790" },
                    { "ab55e317-65d8-43a1-81e7-7a2a3d745051", new DateTime(2024, 11, 3, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4916), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7e4e7427-c28b-406e-a016-48b28d074381" },
                    { "afcf657f-f820-43cd-89e3-c7e73079c9b5", new DateTime(2024, 11, 10, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4940), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "44888132-952a-4b48-8a2e-861610b3ac2e" },
                    { "c8f19835-f014-4735-ab11-86c3b1b30ee9", new DateTime(2024, 11, 11, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4946), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "08f80a89-4e4e-4229-b078-f5848ca8d70d" },
                    { "fa63cda4-c45d-448e-814c-01a6966d1337", new DateTime(2024, 11, 9, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4980), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ae9778f0-d32a-48c5-9e71-3180c710c1bb" }
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1ce1e930-3c6c-4a27-8dd6-274d9220c25c", "Laptop" },
                    { "4989908c-a5a7-40d5-9145-978222a82764", "Home Appliances" },
                    { "51c56838-4502-4b21-b950-641b7e68cfdf", "Accessories" },
                    { "53e803d7-7fe0-47c3-b066-e83ae95fbecb", "Tablet" },
                    { "69427049-5ecc-4d2c-abd9-1f13b018aa01", "Headphones" },
                    { "781a9109-aefb-4f81-9ee4-e9eb999095be", "Gaming" },
                    { "927d3d6b-70d5-440c-8d8b-81be1c57478a", "Smartwatch" },
                    { "c8ded83f-1bcd-48c4-a634-caeb3857a79d", "Earpiece" },
                    { "dd0667ec-847c-4c80-8d2e-b39d087f46a2", "Charger" },
                    { "e7dafc32-8ac4-4335-b563-2e2cc77bdca3", "Fashion" },
                    { "f0e56ab5-6662-4a96-a600-73f73d3eb81d", "Phone" }
                });

            migrationBuilder.InsertData(
                table: "OrderHeaders",
                columns: new[] { "Id", "Carrier", "City", "Name", "OrderDate", "OrderStatus", "PaymentDate", "PaymentDueDate", "PaymentGuidentId", "PaymentStatus", "PhoneNumber", "PostalCode", "SessionId", "ShippingDate", "State", "StreetAddress", "TotalPrice", "TrackingNumber", "UnitPrice", "UserId" },
                values: new object[,]
                {
                    { "096851c4-42d9-4874-b29f-cbc6829c3780", null, "City E", "John Matt", new DateTime(2024, 11, 12, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3957), "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paid", "9876887210", "99654", null, new DateTime(2024, 11, 5, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3957), "State Polaris", "496 Oak St", 87000m, null, 0m, "08f80a89-4e4e-4229-b078-f5848ca8d70d" },
                    { "2ccdd4bb-3f3e-4c12-852a-af93b01fdef1", null, "City H", "Lurge Luck", new DateTime(2024, 11, 4, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3985), "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refunded", "9874543210", "00986", null, new DateTime(2024, 11, 8, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3986), "State", "86 Oak St", 90000m, null, 0m, "e68dfbda-9052-4bd2-b0a4-7ca76e5bdfb9" },
                    { "5a8979e8-00e4-461b-84b9-c8668c2180db", null, "City J", "Ronald Smith", new DateTime(2024, 10, 26, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4000), "Pending", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refunded", "6526543210", "77654", null, new DateTime(2024, 10, 21, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4001), "State Town", "956 Oak St", 67000m, null, 0m, "82e8a82f-489d-4c4b-aa91-1e61d35290a2" },
                    { "6b54be10-6fe2-4dc0-88ab-688bc9bc0b35", null, "City B", "Jane Sunny", new DateTime(2024, 11, 5, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3934), "Delivered", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UnPaid", "98789943210", "67890", null, new DateTime(2024, 11, 9, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3934), "Ajah", "86 Oak St", 19999m, null, 0m, "dc87759f-624b-4744-ad42-941bf5abc596" },
                    { "9bdac360-9713-45e2-8992-3cd7121ea914", null, "City G", "Bana Good", new DateTime(2024, 11, 5, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3973), "Cancelled", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paid", "9898743210", "88978", null, new DateTime(2024, 11, 6, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3973), "State Paris", "6 Oak St", 30000m, null, 0m, "b9418aad-4285-4d05-b354-709ff1ed64db" },
                    { "bd74011e-f7da-440d-b2a7-1dbe201b2081", null, "City C", "James Wis", new DateTime(2024, 11, 4, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3942), "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paid", "9867843210", "77898", null, new DateTime(2024, 11, 4, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3943), " Makurdi", "45 Oak St", 70000m, null, 0m, "04264620-2dc3-4eae-89d2-b8748a2faa5a" },
                    { "ca4f46cd-241a-4c5e-981b-716f5f1a0a58", null, "City A", "John Doe", new DateTime(2024, 11, 3, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3917), "Shipped", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paid", "1234567890", "12345", null, new DateTime(2024, 11, 8, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3924), "Agege", "123 Main St", 9999m, null, 0m, "7e4e7427-c28b-406e-a016-48b28d074381" },
                    { "d8ad4474-094c-4e41-a0ae-a3a5bf800a60", null, "City K", "Jane Adam", new DateTime(2024, 11, 6, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4008), "Shipped", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paid", "9876920210", "88765", null, new DateTime(2024, 11, 10, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4008), "State V", "16 Oak St", 450000m, null, 0m, "ae9778f0-d32a-48c5-9e71-3180c710c1bb" },
                    { "f410a014-01b4-4978-b16c-f9a948052cb1", null, "City F", "Matt Paul", new DateTime(2024, 11, 1, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3964), "Pending", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refunded", "4878743210", "09908", null, new DateTime(2024, 11, 9, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3965), "State New", "76 Oak St", 76000m, null, 0m, "2e2cfc00-0b76-4c61-920e-ed6f43778790" },
                    { "fc877e15-5a41-4977-9e9f-aa2a884b7de5", null, "City I", "Gate Paulo", new DateTime(2024, 10, 30, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3993), "Cancelled", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UnPaid", "9878453210", "00987", null, new DateTime(2024, 10, 30, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3993), "State Mark", "26 Oak St", 98000m, null, 0m, "e7cac291-487f-46b2-a1ab-7ccce946f2d6" },
                    { "ff85683b-a10b-4f5b-bc12-63b6162944dd", null, "City D", "Joan Mark", new DateTime(2024, 11, 7, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3950), "Delivered", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refunded", "9876543210", "78754", null, new DateTime(2024, 11, 9, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3950), "State A", "956 Oak St", 60000m, null, 0m, "44888132-952a-4b48-8a2e-861610b3ac2e" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartegoryId", "CreatedDate", "Description", "ImageUrl", "Price", "ProductStatus", "StockQuantity", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { "0816d206-9b6b-4e93-9392-68e664b58dc5", "1ce1e930-3c6c-4a27-8dd6-274d9220c25c", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3692), "Description of Product 2", "https://example.com/images/product2.jpg", 295000m, 0, 50, "Product 2", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3693) },
                    { "3dec7008-ae6e-4154-aa61-bf7f8670e695", "53e803d7-7fe0-47c3-b066-e83ae95fbecb", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3717), "Description of Product 5", "https://example.com/images/product5.jpg", 900000m, 1, 700, "Product 5", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3718) },
                    { "4b4483be-aef2-4cbe-9561-176533230a2e", "781a9109-aefb-4f81-9ee4-e9eb999095be", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3745), "Description of Product 9", "https://example.com/images/product9.jpg", 780000m, 1, 700, "Product 9", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3745) },
                    { "691880e6-9963-4843-b16a-0caa6db921e8", "927d3d6b-70d5-440c-8d8b-81be1c57478a", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3731), "Description of Product 7", "https://example.com/images/product7.jpg", 7000m, 1, 80, "Product 7", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3731) },
                    { "7670c434-42d3-4a37-a552-2eebb9e5a9ea", "e7dafc32-8ac4-4335-b563-2e2cc77bdca3", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3752), "Description of Product 10", "https://example.com/images/product10.jpg", 56000m, 1, 700, "Product 10", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3752) },
                    { "8250eb3e-0fa1-4276-9f7f-424b827fe26a", "69427049-5ecc-4d2c-abd9-1f13b018aa01", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3724), "Description of Product 6", "https://example.com/images/product6.jpg", 856000m, 1, 900, "Product 6", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3725) },
                    { "88809696-8c47-49bf-bf89-3ae1e24e9c8c", "dd0667ec-847c-4c80-8d2e-b39d087f46a2", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3702), "Description of Product 3", "https://example.com/images/product3.jpg", 49500m, 2, 40, "Product 3", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3703) },
                    { "9ae39737-7d17-4a44-ab9a-a6d5f8230b0b", "4989908c-a5a7-40d5-9145-978222a82764", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3762), "Description of Product 11", "https://example.com/images/product11.jpg", 45000m, 1, 600, "Product 11", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3762) },
                    { "a31627b8-0843-4687-a8ad-c145499adf8c", "51c56838-4502-4b21-b950-641b7e68cfdf", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3738), "Description of Product 8", "https://example.com/images/product8.jpg", 25000m, 1, 800, "Product 8", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3738) },
                    { "eeae9e1f-3afe-4776-827d-5a1e984683b3", "c8ded83f-1bcd-48c4-a634-caeb3857a79d", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3710), "Description of Product 4", "https://example.com/images/product4.jpg", 50000m, 1, 500, "Product 4", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3710) },
                    { "f990b229-ea56-4ed4-8587-ae59eb668bb7", "f0e56ab5-6662-4a96-a600-73f73d3eb81d", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3683), "Description of Product 1", "https://example.com/images/product1.jpg", 170000m, 0, 100, "Product 1", new DateTime(2024, 11, 13, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(3684) }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Count", "OrderHeaderId", "Price", "ProductId", "UserId" },
                values: new object[,]
                {
                    { "22539b11-6d45-429d-ae8a-8b1a6ad34647", 6, "096851c4-42d9-4874-b29f-cbc6829c3780", 55000m, "3dec7008-ae6e-4154-aa61-bf7f8670e695", "08f80a89-4e4e-4229-b078-f5848ca8d70d" },
                    { "363b14a6-8596-4de9-807d-145743e7cfeb", 1, "6b54be10-6fe2-4dc0-88ab-688bc9bc0b35", 2999m, "0816d206-9b6b-4e93-9392-68e664b58dc5", "dc87759f-624b-4744-ad42-941bf5abc596" },
                    { "4edaf8fa-d467-478f-9f44-740e0b81da36", 6, "d8ad4474-094c-4e41-a0ae-a3a5bf800a60", 235000m, "9ae39737-7d17-4a44-ab9a-a6d5f8230b0b", "ae9778f0-d32a-48c5-9e71-3180c710c1bb" },
                    { "59583e0d-9636-4c95-907b-d965d8a2e9b4", 2, "ca4f46cd-241a-4c5e-981b-716f5f1a0a58", 1999m, "f990b229-ea56-4ed4-8587-ae59eb668bb7", "7e4e7427-c28b-406e-a016-48b28d074381" },
                    { "63ba0111-052a-4a21-9d62-8bde5429405e", 5, "2ccdd4bb-3f3e-4c12-852a-af93b01fdef1", 45000m, "a31627b8-0843-4687-a8ad-c145499adf8c", "e68dfbda-9052-4bd2-b0a4-7ca76e5bdfb9" },
                    { "71317e45-0250-4fb0-b5b8-b80a393b1cd8", 9, "f410a014-01b4-4978-b16c-f9a948052cb1", 6700m, "8250eb3e-0fa1-4276-9f7f-424b827fe26a", "2e2cfc00-0b76-4c61-920e-ed6f43778790" },
                    { "72c9994a-e1d7-411b-9668-50a35963397d", 3, "9bdac360-9713-45e2-8992-3cd7121ea914", 8900m, "691880e6-9963-4843-b16a-0caa6db921e8", "b9418aad-4285-4d05-b354-709ff1ed64db" },
                    { "a29b95a5-0439-4f07-8f0f-d3bbb7d3171a", 3, "bd74011e-f7da-440d-b2a7-1dbe201b2081", 4999m, "88809696-8c47-49bf-bf89-3ae1e24e9c8c", "04264620-2dc3-4eae-89d2-b8748a2faa5a" },
                    { "a8ea82d0-8728-4d61-bedb-1633c05f3e82", 8, "fc877e15-5a41-4977-9e9f-aa2a884b7de5", 99000m, "4b4483be-aef2-4cbe-9561-176533230a2e", "e7cac291-487f-46b2-a1ab-7ccce946f2d6" },
                    { "b10e30e2-44b5-4801-9f56-a1c356e51bb7", 5, "ff85683b-a10b-4f5b-bc12-63b6162944dd", 4500m, "eeae9e1f-3afe-4776-827d-5a1e984683b3", "44888132-952a-4b48-8a2e-861610b3ac2e" },
                    { "bcf43e1d-3342-4189-be39-7edc59496068", 7, "5a8979e8-00e4-461b-84b9-c8668c2180db", 8900m, "7670c434-42d3-4a37-a552-2eebb9e5a9ea", "82e8a82f-489d-4c4b-aa91-1e61d35290a2" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CreatedDate", "CustomerId", "ProductId", "Rating" },
                values: new object[,]
                {
                    { "1228b24f-3656-4ed8-b150-a54f2d89b5e8", "Pleased with the quality.", new DateTime(2024, 10, 31, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4709), "b9418aad-4285-4d05-b354-709ff1ed64db", "691880e6-9963-4843-b16a-0caa6db921e8", 4 },
                    { "3780768b-e42c-4545-85b6-0757a27ffab9", "Fairly pleased with the quality.", new DateTime(2024, 11, 11, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4691), "08f80a89-4e4e-4229-b078-f5848ca8d70d", "3dec7008-ae6e-4154-aa61-bf7f8670e695", 2 },
                    { "4ae58da8-9a42-47c2-8af2-79a2088ea032", "Excellent product!", new DateTime(2024, 11, 3, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4659), "7e4e7427-c28b-406e-a016-48b28d074381", "f990b229-ea56-4ed4-8587-ae59eb668bb7", 5 },
                    { "54fe9d40-8f86-4e42-b82f-66b9b35f7f2f", "Good value for the price.", new DateTime(2024, 11, 5, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4669), "dc87759f-624b-4744-ad42-941bf5abc596", "0816d206-9b6b-4e93-9392-68e664b58dc5", 4 },
                    { "6e71fc6e-df2f-4828-b8f4-56ef2393cfd8", "Fairly pleased with the quality.", new DateTime(2024, 11, 10, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4684), "44888132-952a-4b48-8a2e-861610b3ac2e", "eeae9e1f-3afe-4776-827d-5a1e984683b3", 1 },
                    { "7aa2d302-4554-4a73-9287-50442e538bd2", "Partially pleased with the quality.", new DateTime(2024, 11, 9, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4865), "ae9778f0-d32a-48c5-9e71-3180c710c1bb", "9ae39737-7d17-4a44-ab9a-a6d5f8230b0b", 3 },
                    { "940d8265-ef2d-4adf-9736-d34765f3e61d", "Pleased with the quality.", new DateTime(2024, 11, 8, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4698), "2e2cfc00-0b76-4c61-920e-ed6f43778790", "8250eb3e-0fa1-4276-9f7f-424b827fe26a", 4 },
                    { "9c0c03cf-a42d-4265-98be-f7c5d3e63ff7", "Awesome quality.", new DateTime(2024, 11, 9, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4728), "e7cac291-487f-46b2-a1ab-7ccce946f2d6", "4b4483be-aef2-4cbe-9561-176533230a2e", 5 },
                    { "a2e0943c-29bc-4990-95dd-b2ad65dd4170", "Not really a great quality.", new DateTime(2024, 10, 21, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4736), "82e8a82f-489d-4c4b-aa91-1e61d35290a2", "7670c434-42d3-4a37-a552-2eebb9e5a9ea", 2 },
                    { "b717a62c-126c-4799-9b35-e121a75aacfd", "Very very pleased with the quality.", new DateTime(2024, 11, 1, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4716), "e68dfbda-9052-4bd2-b0a4-7ca76e5bdfb9", "a31627b8-0843-4687-a8ad-c145499adf8c", 5 },
                    { "da43f761-28e7-4e64-8fe7-c6f36b4a8bec", "Satisfactory, but could be improved.", new DateTime(2024, 11, 8, 17, 12, 30, 380, DateTimeKind.Utc).AddTicks(4677), "04264620-2dc3-4eae-89d2-b8748a2faa5a", "88809696-8c47-49bf-bf89-3ae1e24e9c8c", 3 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "Count", "ProductId", "ShoppingCartId", "UserId" },
                values: new object[,]
                {
                    { "0f92c4bf-c75c-4a2e-bcf8-12db0c5a1e62", 6, "a31627b8-0843-4687-a8ad-c145499adf8c", "4de67e63-4d16-424c-9225-94302e48232c", "e68dfbda-9052-4bd2-b0a4-7ca76e5bdfb9" },
                    { "28a2762f-9102-4cfe-ad18-6da77d9a6df4", 2, "f990b229-ea56-4ed4-8587-ae59eb668bb7", "ab55e317-65d8-43a1-81e7-7a2a3d745051", "7e4e7427-c28b-406e-a016-48b28d074381" },
                    { "2c190aee-dab8-4f3f-b298-3aeb4d6ac4f7", 5, "eeae9e1f-3afe-4776-827d-5a1e984683b3", "afcf657f-f820-43cd-89e3-c7e73079c9b5", "44888132-952a-4b48-8a2e-861610b3ac2e" },
                    { "359b1ff5-4c63-42d9-af95-a9065598ac82", 5, "9ae39737-7d17-4a44-ab9a-a6d5f8230b0b", "fa63cda4-c45d-448e-814c-01a6966d1337", "ae9778f0-d32a-48c5-9e71-3180c710c1bb" },
                    { "4bad18f4-6d23-40f1-a316-0eb6ac3ccca8", 4, "88809696-8c47-49bf-bf89-3ae1e24e9c8c", "1631fcfe-f664-43d2-a3fe-6b28ca3a39e8", "04264620-2dc3-4eae-89d2-b8748a2faa5a" },
                    { "516b3377-f15e-4e77-8e04-88af7dbb4817", 3, "3dec7008-ae6e-4154-aa61-bf7f8670e695", "c8f19835-f014-4735-ab11-86c3b1b30ee9", "08f80a89-4e4e-4229-b078-f5848ca8d70d" },
                    { "57100dce-8c13-428f-b96a-615f77ad844e", 8, "4b4483be-aef2-4cbe-9561-176533230a2e", "41e405ba-d11d-42d7-b462-94ec83f95fc8", "e7cac291-487f-46b2-a1ab-7ccce946f2d6" },
                    { "5980288c-53c5-44fb-b1d5-dcbb3e2528d9", 6, "691880e6-9963-4843-b16a-0caa6db921e8", "3a5ab03f-9a51-435b-965c-b6027efc610a", "b9418aad-4285-4d05-b354-709ff1ed64db" },
                    { "8c811be1-a4f9-401d-8f6d-0cb7f741c47c", 1, "0816d206-9b6b-4e93-9392-68e664b58dc5", "3c89ecf9-0784-4163-a2b2-8efb6db322d6", "dc87759f-624b-4744-ad42-941bf5abc596" },
                    { "d09e0e6f-0b3e-4ffd-9742-82ed1427f901", 8, "7670c434-42d3-4a37-a552-2eebb9e5a9ea", "0234b431-517a-4e0b-9c54-6cdf1ed98394", "82e8a82f-489d-4c4b-aa91-1e61d35290a2" },
                    { "f4d4a3ef-057f-4d68-8d55-f9216efaefaf", 5, "8250eb3e-0fa1-4276-9f7f-424b827fe26a", "8e773d84-3a2f-4230-82c0-9ff2af6d118e", "2e2cfc00-0b76-4c61-920e-ed6f43778790" }
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

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_UserId",
                table: "ShoppingCartItems",
                column: "UserId");
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

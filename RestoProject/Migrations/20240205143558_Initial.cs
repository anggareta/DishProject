using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestoProject.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DishOrders",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishOrders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visits = table.Column<int>(type: "int", nullable: false),
                    LastVisit = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TMCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TMFlavor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMFlavor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishId = table.Column<int>(type: "int", nullable: false),
                    FlavorId = table.Column<int>(type: "int", nullable: false),
                    DishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlavorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_DishOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "DishOrders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TMDish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Views = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMDish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TMDish_TMCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TMCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TTDishVariant",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    FlavorId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTDishVariant", x => new { x.DishId, x.FlavorId });
                    table.ForeignKey(
                        name: "FK_TTDishVariant_TMDish_DishId",
                        column: x => x.DishId,
                        principalTable: "TMDish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TTDishVariant_TMFlavor_FlavorId",
                        column: x => x.FlavorId,
                        principalTable: "TMFlavor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DishOrders",
                columns: new[] { "OrderId", "Description", "Name", "OrderTime" },
                values: new object[] { "ABC01012024-001", "Tolong sambel dipisah...", "Ayus", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TMCategory",
                columns: new[] { "Id", "Icon", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "bi-list-nested-nav-menu", "Foods", "foods" },
                    { 2, "bi-list-nested-nav-menu", "Drinks", "drinks" },
                    { 3, "bi-list-nested-nav-menu", "Desserts", "desserts" }
                });

            migrationBuilder.InsertData(
                table: "TMFlavor",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kambing" },
                    { 2, "Sapi" },
                    { 3, "Ayam" },
                    { 4, "Ikan" },
                    { 5, "Vanila" },
                    { 6, "Coklat" },
                    { 7, "Stroberi" },
                    { 8, "Alpukat" },
                    { 9, "ala-carte" },
                    { 10, "tambah Nasi" },
                    { 11, "tambah Lontong" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { "admin", "Admin", "6a67e39f6ecf03658deb4f130682ae18269c3c31083b191213cbbb27f8ece75f", 0 },
                    { "meja_1", "Meja 1", "6a67e39f6ecf03658deb4f130682ae18269c3c31083b191213cbbb27f8ece75f", 1 },
                    { "meja_2", "Meja 2", "6a67e39f6ecf03658deb4f130682ae18269c3c31083b191213cbbb27f8ece75f", 1 },
                    { "meja_3", "Meja 3", "6a67e39f6ecf03658deb4f130682ae18269c3c31083b191213cbbb27f8ece75f", 1 }
                });

            migrationBuilder.InsertData(
                table: "TMDish",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateUpdated", "Description", "Image", "IsDeleted", "IsPublic", "Name", "Views" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nasi goreng adalah makanan jalanan populer di Asia. Di beberapa negara Asia, restoran-restoran kecil, gerai-gerai pinggir jalan dan pedagang keliling mengkhususkan diri dalam menyajikan nasi goreng.", "https://placehold.co/200x200/png?text=Nasi+Goreng\\nKambing", false, false, "Nasi Goreng Kambing", 0 },
                    { 2, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sate kambing adalah sejenis makanan sate terbuat dari daging kambing. daging kambing tersebut disate (ditusuk dengan bambu yang dibentuk seperti lidi yang agak besar) dan dibumbui dengan rempah-rempah dan bumbu dapur, kemudian dibakar.", "https://placehold.co/200x200/png?text=Sate+Kambing", false, false, "Sate Kambing", 0 },
                    { 3, 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jus atau sari adalah minuman yang terbuat dari ekstraksi atau pemerasan cairan alami yang terkandung dalam buah dan sayuran.", "https://placehold.co/200x200/png?text=Jus", false, false, "Jus", 0 },
                    { 4, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Es krim' merupakan sebuah makanan beku yang dibuat dari produk susu seperti krim, lalu dicampur dengan perasa dan pemanis buatan ataupun alami. terdapat beberapa vaian rasa", "https://placehold.co/200x200/png?text=Ice+Cream", false, false, "Es Krim", 0 }
                });

            migrationBuilder.InsertData(
                table: "TTDishVariant",
                columns: new[] { "DishId", "FlavorId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 1, 18.00m, 18.00m },
                    { 2, 1, 30.00m, 30.00m },
                    { 2, 10, 30.00m, 35.00m },
                    { 2, 11, 30.00m, 37.00m },
                    { 3, 7, 12.00m, 12.00m },
                    { 3, 8, 10.00m, 13.00m },
                    { 4, 5, 10.00m, 11.00m },
                    { 4, 6, 10.00m, 11.50m },
                    { 4, 7, 10.00m, 12.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderId",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TMDish_CategoryId",
                table: "TMDish",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TTDishVariant_FlavorId",
                table: "TTDishVariant",
                column: "FlavorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "TTDishVariant");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DishOrders");

            migrationBuilder.DropTable(
                name: "TMDish");

            migrationBuilder.DropTable(
                name: "TMFlavor");

            migrationBuilder.DropTable(
                name: "TMCategory");
        }
    }
}

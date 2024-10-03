using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiECommerce.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Popular = table.Column<bool>(type: "bit", nullable: false),
                    BestSeller = table.Column<bool>(type: "bit", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "UrlImage" },
                values: new object[,]
                {
                    { 1, "Snacks", "lanches1.png" },
                    { 2, "Combos", "combos1.png" },
                    { 3, "Natural", "naturais1.png" },
                    { 4, "Drinks", "refrigerantes1.png" },
                    { 5, "Juices", "sucos1.png" },
                    { 6, "Desserts", "sobremesas1.png" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "BestSeller", "CategoryId", "Details", "Name", "Popular", "Price", "Stock", "UrlImage" },
                values: new object[,]
                {
                    { 1, true, true, 1, "Soft bread, seasoned beef hamburger, onion, mustard, and ketchup ", "Standard Hamburger", true, 15m, 13, "hamburger1.jpeg" },
                    { 2, true, false, 1, "Soft bread, seasoned beef hamburger, and cheese all around.", "Standard Cheeseburger", true, 18m, 10, "hamburger3.jpeg" },
                    { 3, true, false, 1, "Soft bread, seasoned beef hamburger, onion, lettuce, mustard, and ketchup ", "Standard Cheese Salad", false, 19m, 13, "hamburger4.jpeg" },
                    { 4, false, false, 2, "Soft bread, seasoned beef hamburger and cheese, soda, and fries", "Hamburger, fries, soda", true, 25m, 10, "combo1.jpeg" },
                    { 5, true, false, 2, "Soft bread, seasoned beef hamburger, soda, and fries, onion, mayonnaise, and ketchup", "Cheeseburger, fries, soda", false, 27m, 13, "combo2.jpeg" },
                    { 6, true, false, 2, "Soft bread, seasoned beef hamburger, soda, and fries, onion, mayonnaise, and ketchup", "Cheese Salad, fries, soda", true, 28m, 10, "combo3.jpeg" },
                    { 7, true, false, 3, "Whole grain bread with greens and tomato", "Natural Snack with greens", false, 14m, 13, "lanche_natural1.jpeg" },
                    { 8, true, false, 3, "Whole grain bread, greens, tomato, and cheese.", "Natural Snack and cheese", true, 15m, 10, "lanche_natural2.jpeg" },
                    { 9, true, false, 3, "Vegan snack with healthy ingredients", "Vegan Snack", false, 25m, 18, "lanche_vegano1.jpeg" },
                    { 10, true, false, 4, "Coca-Cola soda", "Coca-Cola", true, 21m, 7, "coca_cola1.jpeg" },
                    { 11, true, false, 4, "Guaraná soda", "Guaraná", false, 25m, 6, "guarana1.jpeg" },
                    { 12, true, false, 4, "Pepsi Cola soda", "Pepsi", false, 21m, 6, "pepsi1.jpeg" },
                    { 13, true, false, 5, "Delicious and nutritious orange juice", "Orange Juice", false, 11m, 10, "suco_laranja.jpeg" },
                    { 14, true, false, 5, "Fresh strawberry juice", "Strawberry Juice", false, 15m, 13, "suco_morango1.jpeg" },
                    { 15, true, false, 5, "Natural grape juice without sugar made with the fruit", "Grape Juice", false, 13m, 10, "suco_uva1.jpeg" },
                    { 16, true, false, 4, "Fresh natural mineral water", "Water", false, 5m, 10, "agua_mineral1.jpeg" },
                    { 17, true, false, 6, "Chocolate cookies with chocolate chunks", "Chocolate Cookies", true, 8m, 10, "cookie1.jpeg" },
                    { 18, true, true, 6, "Delicious and crunchy vanilla cookies", "Vanilla Cookies", false, 8m, 13, "cookie2.jpeg" },
                    { 19, true, false, 6, "Swiss pie with cream and layers of dulce de leche", "Swiss Pie", true, 10m, 10, "torta_suica1.jpeg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiECommerce.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
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
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
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
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "lanches1.png", "Snacks" },
                    { 2, "combos1.png", "Combos" },
                    { 3, "naturais1.png", "Natural" },
                    { 4, "refrigerantes1.png", "Drinks" },
                    { 5, "sucos1.png", "Juices" },
                    { 6, "sobremesas1.png", "Desserts" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "BestSeller", "CategoryId", "Details", "ImageUrl", "Name", "Popular", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, true, true, 1, "Soft bread, seasoned beef hamburger, onion, mustard, and ketchup ", "hamburger1.jpeg", "Standard Hamburger", true, 15m, 13 },
                    { 2, true, false, 1, "Soft bread, seasoned beef hamburger, and cheese all around.", "hamburger3.jpeg", "Standard Cheeseburger", true, 18m, 10 },
                    { 3, true, false, 1, "Soft bread, seasoned beef hamburger, onion, lettuce, mustard, and ketchup ", "hamburger4.jpeg", "Standard Cheese Salad", false, 19m, 13 },
                    { 4, false, false, 2, "Soft bread, seasoned beef hamburger and cheese, soda, and fries", "combo1.jpeg", "Hamburger, fries, soda", true, 25m, 10 },
                    { 5, true, false, 2, "Soft bread, seasoned beef hamburger, soda, and fries, onion, mayonnaise, and ketchup", "combo2.jpeg", "Cheeseburger, fries, soda", false, 27m, 13 },
                    { 6, true, false, 2, "Soft bread, seasoned beef hamburger, soda, and fries, onion, mayonnaise, and ketchup", "combo3.jpeg", "Cheese Salad, fries, soda", true, 28m, 10 },
                    { 7, true, false, 3, "Whole grain bread with greens and tomato", "lanche_natural1.jpeg", "Natural Snack with greens", false, 14m, 13 },
                    { 8, true, false, 3, "Whole grain bread, greens, tomato, and cheese.", "lanche_natural2.jpeg", "Natural Snack and cheese", true, 15m, 10 },
                    { 9, true, false, 3, "Vegan snack with healthy ingredients", "lanche_vegano1.jpeg", "Vegan Snack", false, 25m, 18 },
                    { 10, true, false, 4, "Coca-Cola soda", "coca_cola1.jpeg", "Coca-Cola", true, 21m, 7 },
                    { 11, true, false, 4, "Guaraná soda", "guarana1.jpeg", "Guaraná", false, 25m, 6 },
                    { 12, true, false, 4, "Pepsi Cola soda", "pepsi1.jpeg", "Pepsi", false, 21m, 6 },
                    { 13, true, false, 5, "Delicious and nutritious orange juice", "suco_laranja.jpeg", "Orange Juice", false, 11m, 10 },
                    { 14, true, false, 5, "Fresh strawberry juice", "suco_morango1.jpeg", "Strawberry Juice", false, 15m, 13 },
                    { 15, true, false, 5, "Natural grape juice without sugar made with the fruit", "suco_uva1.jpeg", "Grape Juice", false, 13m, 10 },
                    { 16, true, false, 4, "Fresh natural mineral water", "agua_mineral1.jpeg", "Water", false, 5m, 10 },
                    { 17, true, false, 6, "Chocolate cookies with chocolate chunks", "cookie1.jpeg", "Chocolate Cookies", true, 8m, 10 },
                    { 18, true, true, 6, "Delicious and crunchy vanilla cookies", "cookie2.jpeg", "Vanilla Cookies", false, 8m, 13 },
                    { 19, true, false, 6, "Swiss pie with cream and layers of dulce de leche", "torta_suica1.jpeg", "Swiss Pie", true, 10m, 10 }
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

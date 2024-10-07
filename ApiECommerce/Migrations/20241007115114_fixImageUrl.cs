using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiECommerce.Migrations
{
    /// <inheritdoc />
    public partial class fixImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlImage",
                table: "Products",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "UrlImage",
                table: "Categories",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "UrlImage");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Categories",
                newName: "UrlImage");
        }
    }
}

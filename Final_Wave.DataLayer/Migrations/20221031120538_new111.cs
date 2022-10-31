using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Wave.DataLayer.Migrations
{
    public partial class new111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_products_ProductId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "orders",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_ProductId",
                table: "orders",
                newName: "IX_orders_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_categories_CategoryId",
                table: "orders",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_categories_CategoryId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "orders",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_CategoryId",
                table: "orders",
                newName: "IX_orders_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products_ProductId",
                table: "orders",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

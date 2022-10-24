using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Wave.DataLayer.Migrations
{
    public partial class userprofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_categories_CategoryId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_CategoryId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "usrimag",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usrimag",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_CategoryId",
                table: "orders",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_categories_CategoryId",
                table: "orders",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }
    }
}

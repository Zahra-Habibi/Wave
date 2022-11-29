using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Wave.DataLayer.Migrations
{
    public partial class newprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "count",
                table: "ProductPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count",
                table: "ProductPrice");

            migrationBuilder.AddColumn<int>(
                name: "count",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Wave.DataLayer.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

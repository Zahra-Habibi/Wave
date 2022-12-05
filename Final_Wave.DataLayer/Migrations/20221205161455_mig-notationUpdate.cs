using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Wave.DataLayer.Migrations
{
    public partial class mignotationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccept",
                table: "Notation_tbl",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccept",
                table: "Notation_tbl");
        }
    }
}

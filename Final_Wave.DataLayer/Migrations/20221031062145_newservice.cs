using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Wave.DataLayer.Migrations
{
    public partial class newservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "services",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "services");
        }
    }
}

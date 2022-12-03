using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Wave.DataLayer.Migrations
{
    public partial class notation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notation_tbl",
                columns: table => new
                {
                    NotationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotationContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID_Creator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserID_Reciever = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notation_tbl", x => x.NotationID);
                    table.ForeignKey(
                        name: "FK_Notation_tbl_AspNetUsers_UserID_Creator",
                        column: x => x.UserID_Creator,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notation_tbl_AspNetUsers_UserID_Reciever",
                        column: x => x.UserID_Reciever,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notation_tbl_UserID_Creator",
                table: "Notation_tbl",
                column: "UserID_Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Notation_tbl_UserID_Reciever",
                table: "Notation_tbl",
                column: "UserID_Reciever");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notation_tbl");
        }
    }
}

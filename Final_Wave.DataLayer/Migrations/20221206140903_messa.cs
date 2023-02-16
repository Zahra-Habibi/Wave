using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Wave.DataLayer.Migrations
{
    public partial class messa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chatmessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID_Creator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserID_Reciever = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatmessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chatmessage_AspNetUsers_UserID_Creator",
                        column: x => x.UserID_Creator,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_chatmessage_AspNetUsers_UserID_Reciever",
                        column: x => x.UserID_Reciever,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_chatmessage_UserID_Creator",
                table: "chatmessage",
                column: "UserID_Creator");

            migrationBuilder.CreateIndex(
                name: "IX_chatmessage_UserID_Reciever",
                table: "chatmessage",
                column: "UserID_Reciever");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chatmessage");
        }
    }
}

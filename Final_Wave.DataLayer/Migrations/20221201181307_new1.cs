using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Wave.DataLayer.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_UserID",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Message",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Message",
                newName: "userId_reciever");

            migrationBuilder.RenameIndex(
                name: "IX_Message_UserID",
                table: "Message",
                newName: "IX_Message_userId_reciever");

            migrationBuilder.AddColumn<bool>(
                name: "IsSend",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "userId_sender",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_userId_reciever",
                table: "Message",
                column: "userId_reciever",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_userId_reciever",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "IsSend",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "userId_sender",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "userId_reciever",
                table: "Message",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Message",
                newName: "UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Message_userId_reciever",
                table: "Message",
                newName: "IX_Message_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_UserID",
                table: "Message",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

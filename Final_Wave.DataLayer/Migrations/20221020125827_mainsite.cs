using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Wave.DataLayer.Migrations
{
    public partial class mainsite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_UserID",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_UserID",
                table: "Message");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Message",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                table: "Message",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_SenderId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Message");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Message",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserID",
                table: "Message",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_UserID",
                table: "Message",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

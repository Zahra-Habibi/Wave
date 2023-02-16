using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Wave.DataLayer.Migrations
{
    public partial class prograss1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prograssBars_AspNetUsers_UserId",
                table: "prograssBars");

            migrationBuilder.DropForeignKey(
                name: "FK_prograssBars_orders_orderid",
                table: "prograssBars");

            migrationBuilder.RenameColumn(
                name: "orderid",
                table: "prograssBars",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "prograssBars",
                newName: "UserID_Reciever");

            migrationBuilder.RenameIndex(
                name: "IX_prograssBars_orderid",
                table: "prograssBars",
                newName: "IX_prograssBars_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_prograssBars_UserId",
                table: "prograssBars",
                newName: "IX_prograssBars_UserID_Reciever");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "prograssBars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserID_Creator",
                table: "prograssBars",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_prograssBars_UserID_Creator",
                table: "prograssBars",
                column: "UserID_Creator");

            migrationBuilder.AddForeignKey(
                name: "FK_prograssBars_AspNetUsers_UserID_Creator",
                table: "prograssBars",
                column: "UserID_Creator",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_prograssBars_AspNetUsers_UserID_Reciever",
                table: "prograssBars",
                column: "UserID_Reciever",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_prograssBars_orders_OrderId",
                table: "prograssBars",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prograssBars_AspNetUsers_UserID_Creator",
                table: "prograssBars");

            migrationBuilder.DropForeignKey(
                name: "FK_prograssBars_AspNetUsers_UserID_Reciever",
                table: "prograssBars");

            migrationBuilder.DropForeignKey(
                name: "FK_prograssBars_orders_OrderId",
                table: "prograssBars");

            migrationBuilder.DropIndex(
                name: "IX_prograssBars_UserID_Creator",
                table: "prograssBars");

            migrationBuilder.DropColumn(
                name: "UserID_Creator",
                table: "prograssBars");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "prograssBars",
                newName: "orderid");

            migrationBuilder.RenameColumn(
                name: "UserID_Reciever",
                table: "prograssBars",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_prograssBars_OrderId",
                table: "prograssBars",
                newName: "IX_prograssBars_orderid");

            migrationBuilder.RenameIndex(
                name: "IX_prograssBars_UserID_Reciever",
                table: "prograssBars",
                newName: "IX_prograssBars_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "orderid",
                table: "prograssBars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_prograssBars_AspNetUsers_UserId",
                table: "prograssBars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_prograssBars_orders_orderid",
                table: "prograssBars",
                column: "orderid",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

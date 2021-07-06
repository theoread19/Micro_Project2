using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "message-table",
                newName: "senderId");

            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "message-table",
                newName: "recipientId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "message-table",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 6, 8, 54, 57, 172, DateTimeKind.Local).AddTicks(1864),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2021, 6, 29, 14, 46, 7, 366, DateTimeKind.Local).AddTicks(9341));

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_message-table_recipientId",
                table: "message-table",
                column: "recipientId");

            migrationBuilder.CreateIndex(
                name: "IX_message-table_senderId",
                table: "message-table",
                column: "senderId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Message_Re",
                table: "message-table",
                column: "recipientId",
                principalTable: "UserModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Message_Se",
                table: "message-table",
                column: "senderId",
                principalTable: "UserModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Message_Re",
                table: "message-table");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Message_Se",
                table: "message-table");

            migrationBuilder.DropTable(
                name: "UserModels");

            migrationBuilder.DropIndex(
                name: "IX_message-table_recipientId",
                table: "message-table");

            migrationBuilder.DropIndex(
                name: "IX_message-table_senderId",
                table: "message-table");

            migrationBuilder.RenameColumn(
                name: "senderId",
                table: "message-table",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "recipientId",
                table: "message-table",
                newName: "RecipientId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "message-table",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 14, 46, 7, 366, DateTimeKind.Local).AddTicks(9341),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2021, 7, 6, 8, 54, 57, 172, DateTimeKind.Local).AddTicks(1864));
        }
    }
}

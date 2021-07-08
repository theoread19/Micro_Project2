using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class V0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "message-table",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    senderId = table.Column<long>(type: "bigint", nullable: false),
                    recipientId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValue: new DateTime(2021, 7, 8, 16, 59, 14, 899, DateTimeKind.Local).AddTicks(1546))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message-table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Message_Re",
                        column: x => x.recipientId,
                        principalTable: "UserModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Message_Se",
                        column: x => x.senderId,
                        principalTable: "UserModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_message-table_recipientId",
                table: "message-table",
                column: "recipientId");

            migrationBuilder.CreateIndex(
                name: "IX_message-table_senderId",
                table: "message-table",
                column: "senderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "message-table");

            migrationBuilder.DropTable(
                name: "UserModels");
        }
    }
}

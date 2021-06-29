using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user-table",
                table: "user-table");

            migrationBuilder.RenameTable(
                name: "user-table",
                newName: "message-table");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "message-table",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 14, 46, 7, 366, DateTimeKind.Local).AddTicks(9341),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2021, 6, 29, 14, 44, 44, 335, DateTimeKind.Local).AddTicks(8361));

            migrationBuilder.AddPrimaryKey(
                name: "PK_message-table",
                table: "message-table",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_message-table",
                table: "message-table");

            migrationBuilder.RenameTable(
                name: "message-table",
                newName: "user-table");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "user-table",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 14, 44, 44, 335, DateTimeKind.Local).AddTicks(8361),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2021, 6, 29, 14, 46, 7, 366, DateTimeKind.Local).AddTicks(9341));

            migrationBuilder.AddPrimaryKey(
                name: "PK_user-table",
                table: "user-table",
                column: "Id");
        }
    }
}

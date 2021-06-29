using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class V0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user-table",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    RecipientId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValue: new DateTime(2021, 6, 29, 14, 44, 44, 335, DateTimeKind.Local).AddTicks(8361))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user-table", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user-table");
        }
    }
}

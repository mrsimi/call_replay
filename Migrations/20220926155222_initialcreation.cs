using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace call_replay.Migrations
{
    public partial class initialcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WishLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonWishing = table.Column<string>(type: "TEXT", nullable: true),
                    WishAudio = table.Column<byte[]>(type: "BLOB", nullable: true),
                    AudioFileUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishLogs");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabloid.Infrastructure.Migrations
{
    public partial class AddAlbumType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlbumType",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumType",
                table: "Albums");
        }
    }
}

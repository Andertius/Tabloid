﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabloid.Infrastructure.Migrations
{
    public partial class AddTabName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tabs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tabs");
        }
    }
}
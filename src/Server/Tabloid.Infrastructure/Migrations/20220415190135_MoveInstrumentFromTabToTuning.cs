using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabloid.Infrastructure.Migrations
{
    public partial class MoveInstrumentFromTabToTuning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instrument",
                table: "Tabs");

            migrationBuilder.RenameColumn(
                name: "Tuning",
                table: "Tunings",
                newName: "Strings");

            migrationBuilder.RenameIndex(
                name: "IX_Tunings_Tuning",
                table: "Tunings",
                newName: "IX_Tunings_Strings");

            migrationBuilder.AddColumn<int>(
                name: "Instrument",
                table: "Tunings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "FullyMastered",
                table: "Songs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFavourite",
                table: "Songs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instrument",
                table: "Tunings");

            migrationBuilder.DropColumn(
                name: "FullyMastered",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "IsFavourite",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "Strings",
                table: "Tunings",
                newName: "Tuning");

            migrationBuilder.RenameIndex(
                name: "IX_Tunings_Strings",
                table: "Tunings",
                newName: "IX_Tunings_Tuning");

            migrationBuilder.AddColumn<string>(
                name: "Instrument",
                table: "Tabs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

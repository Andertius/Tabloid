using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabloid.Infrastructure.Migrations
{
    public partial class MakeTuningUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tuning",
                table: "Tunings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tunings_Tuning",
                table: "Tunings",
                column: "Tuning",
                unique: true,
                filter: "[Tuning] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tunings_Tuning",
                table: "Tunings");

            migrationBuilder.AlterColumn<string>(
                name: "Tuning",
                table: "Tunings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}

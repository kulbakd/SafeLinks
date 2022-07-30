using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafeLinks.Infrastructure.Migrations
{
    public partial class AddShortcutEditGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EditGuid",
                table: "Shortcuts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditGuid",
                table: "Shortcuts");
        }
    }
}

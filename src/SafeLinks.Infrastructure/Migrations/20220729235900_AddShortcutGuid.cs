using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafeLinks.Infrastructure.Migrations
{
    public partial class AddShortcutGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_SafetyAnalyses_SafetyAnalysisId",
                table: "Link");

            migrationBuilder.AddColumn<string>(
                name: "ShortGuid",
                table: "Shortcuts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "SafetyAnalysisId",
                table: "Link",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_SafetyAnalyses_SafetyAnalysisId",
                table: "Link",
                column: "SafetyAnalysisId",
                principalTable: "SafetyAnalyses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_SafetyAnalyses_SafetyAnalysisId",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "ShortGuid",
                table: "Shortcuts");

            migrationBuilder.AlterColumn<int>(
                name: "SafetyAnalysisId",
                table: "Link",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_SafetyAnalyses_SafetyAnalysisId",
                table: "Link",
                column: "SafetyAnalysisId",
                principalTable: "SafetyAnalyses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

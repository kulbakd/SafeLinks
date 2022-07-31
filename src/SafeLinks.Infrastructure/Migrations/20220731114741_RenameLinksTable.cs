using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafeLinks.Infrastructure.Migrations
{
    public partial class RenameLinksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_SafetyAnalyses_SafetyAnalysisId",
                table: "Link");

            migrationBuilder.DropForeignKey(
                name: "FK_Shortcuts_Link_LinkId",
                table: "Shortcuts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Link",
                table: "Link");

            migrationBuilder.RenameTable(
                name: "Link",
                newName: "Links");

            migrationBuilder.RenameIndex(
                name: "IX_Link_SafetyAnalysisId",
                table: "Links",
                newName: "IX_Links_SafetyAnalysisId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Links",
                table: "Links",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_SafetyAnalyses_SafetyAnalysisId",
                table: "Links",
                column: "SafetyAnalysisId",
                principalTable: "SafetyAnalyses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shortcuts_Links_LinkId",
                table: "Shortcuts",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_SafetyAnalyses_SafetyAnalysisId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Shortcuts_Links_LinkId",
                table: "Shortcuts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Links",
                table: "Links");

            migrationBuilder.RenameTable(
                name: "Links",
                newName: "Link");

            migrationBuilder.RenameIndex(
                name: "IX_Links_SafetyAnalysisId",
                table: "Link",
                newName: "IX_Link_SafetyAnalysisId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Link",
                table: "Link",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_SafetyAnalyses_SafetyAnalysisId",
                table: "Link",
                column: "SafetyAnalysisId",
                principalTable: "SafetyAnalyses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shortcuts_Link_LinkId",
                table: "Shortcuts",
                column: "LinkId",
                principalTable: "Link",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_FootballBetting.Migrations
{
    public partial class editingMistake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Players_PlayerId",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_PlayerId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Bets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Bets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bets_PlayerId",
                table: "Bets",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Players_PlayerId",
                table: "Bets",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

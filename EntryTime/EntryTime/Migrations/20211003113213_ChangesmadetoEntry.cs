using Microsoft.EntityFrameworkCore.Migrations;

namespace EntryTime.Migrations
{
    public partial class ChangesmadetoEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Entries");

            migrationBuilder.CreateIndex(
                name: "IX_Breaks_EntryID",
                table: "Breaks",
                column: "EntryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Breaks_Entries_EntryID",
                table: "Breaks",
                column: "EntryID",
                principalTable: "Entries",
                principalColumn: "EntryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breaks_Entries_EntryID",
                table: "Breaks");

            migrationBuilder.DropIndex(
                name: "IX_Breaks_EntryID",
                table: "Breaks");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

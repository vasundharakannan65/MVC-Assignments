using Microsoft.EntityFrameworkCore.Migrations;

namespace DA.Migrations
{
    public partial class Entrychnaged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breaks_Entries_EntryID",
                table: "Breaks");

            migrationBuilder.AlterColumn<int>(
                name: "EntryID",
                table: "Breaks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Breaks_Entries_EntryID",
                table: "Breaks",
                column: "EntryID",
                principalTable: "Entries",
                principalColumn: "EntryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breaks_Entries_EntryID",
                table: "Breaks");

            migrationBuilder.AlterColumn<int>(
                name: "EntryID",
                table: "Breaks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Breaks_Entries_EntryID",
                table: "Breaks",
                column: "EntryID",
                principalTable: "Entries",
                principalColumn: "EntryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

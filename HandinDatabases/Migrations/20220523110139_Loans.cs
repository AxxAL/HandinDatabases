using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandinDatabases.Migrations
{
    public partial class Loans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Loans_StudentId",
                table: "Loans",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Students_StudentId",
                table: "Loans",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Students_StudentId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_StudentId",
                table: "Loans");
        }
    }
}

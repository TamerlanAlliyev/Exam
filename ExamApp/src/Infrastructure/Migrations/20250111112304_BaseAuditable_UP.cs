using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BaseAuditable_UP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Number",
                table: "Teachers",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Number",
                table: "Students",
                column: "Number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_Number",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_Number",
                table: "Students");
        }
    }
}

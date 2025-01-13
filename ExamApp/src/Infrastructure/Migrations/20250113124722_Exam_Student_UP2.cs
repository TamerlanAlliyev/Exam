using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Exam_Student_UP2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExamResult_ExamId",
                table: "ExamResult");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_ExamId",
                table: "ExamResult",
                column: "ExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExamResult_ExamId",
                table: "ExamResult");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_ExamId",
                table: "ExamResult",
                column: "ExamId",
                unique: true);
        }
    }
}

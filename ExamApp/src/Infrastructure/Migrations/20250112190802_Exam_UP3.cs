using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Exam_UP3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Exams_ExamId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_ExamId",
                table: "Lessons");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_LessonId",
                table: "Exams",
                column: "LessonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Lessons_LessonId",
                table: "Exams",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Lessons_LessonId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_LessonId",
                table: "Exams");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ExamId",
                table: "Lessons",
                column: "ExamId",
                unique: true,
                filter: "[ExamId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Exams_ExamId",
                table: "Lessons",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id");
        }
    }
}

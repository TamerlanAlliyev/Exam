using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Exam_Student_UP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ExamResult_ExamResultId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ExamResultId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "ExamResult",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_StudentId",
                table: "ExamResult",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_Students_StudentId",
                table: "ExamResult",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_Students_StudentId",
                table: "ExamResult");

            migrationBuilder.DropIndex(
                name: "IX_ExamResult_StudentId",
                table: "ExamResult");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ExamResult");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ExamResultId",
                table: "Students",
                column: "ExamResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ExamResult_ExamResultId",
                table: "Students",
                column: "ExamResultId",
                principalTable: "ExamResult",
                principalColumn: "Id");
        }
    }
}

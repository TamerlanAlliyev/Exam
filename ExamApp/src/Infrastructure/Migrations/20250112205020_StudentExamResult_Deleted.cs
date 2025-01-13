using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StudentExamResult_Deleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentExamResult");

            migrationBuilder.AddColumn<int>(
                name: "ExamResultId",
                table: "Students",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ExamResult_ExamResultId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ExamResultId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ExamResultId",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "StudentExamResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ExamResultId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExamResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentExamResult_ExamResult_ExamResultId",
                        column: x => x.ExamResultId,
                        principalTable: "ExamResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentExamResult_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamResult_ExamResultId",
                table: "StudentExamResult",
                column: "ExamResultId");
        }
    }
}

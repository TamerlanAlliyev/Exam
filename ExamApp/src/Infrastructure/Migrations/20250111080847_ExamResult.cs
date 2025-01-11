using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExamResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonAverage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ExamRes = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Average = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamResult_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_ExamResult_ExamId",
                table: "ExamResult",
                column: "ExamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamResult_ExamResultId",
                table: "StudentExamResult",
                column: "ExamResultId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentExamResult");

            migrationBuilder.DropTable(
                name: "ExamResult");
        }
    }
}

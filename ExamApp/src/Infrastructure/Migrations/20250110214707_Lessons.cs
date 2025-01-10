using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Lessons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_SchoolClasses_SchoolClassId",
                table: "Lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson");

            migrationBuilder.RenameTable(
                name: "Lesson",
                newName: "Lessons");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_SchoolClassId",
                table: "Lessons",
                newName: "IX_Lessons_SchoolClassId");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolClassId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_SchoolClasses_SchoolClassId",
                table: "Lessons",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Teachers_TeacherId",
                table: "Lessons",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_SchoolClasses_SchoolClassId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Teachers_TeacherId",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Lessons");

            migrationBuilder.RenameTable(
                name: "Lessons",
                newName: "Lesson");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_SchoolClassId",
                table: "Lesson",
                newName: "IX_Lesson_SchoolClassId");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolClassId",
                table: "Lesson",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_SchoolClasses_SchoolClassId",
                table: "Lesson",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id");
        }
    }
}

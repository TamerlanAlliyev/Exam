using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Students : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.AddColumn<int>(
                name: "SchoolClassId",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_SchoolClassId",
                table: "Lesson",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolClassId",
                table: "Students",
                column: "SchoolClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_SchoolClasses_SchoolClassId",
                table: "Lesson",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SchoolClasses_SchoolClassId",
                table: "Students",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_SchoolClasses_SchoolClassId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_SchoolClasses_SchoolClassId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_SchoolClassId",
                table: "Lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SchoolClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolClassId",
                table: "Lesson");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");
        }
    }
}

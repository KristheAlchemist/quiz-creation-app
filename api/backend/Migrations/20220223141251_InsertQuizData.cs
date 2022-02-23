using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertQuizData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Quizzes", new string[] { "Title", "TeacherId" }, new object[] { "Quiz 1", "1" });
            migrationBuilder.InsertData("Quizzes", new string[] { "Title", "TeacherId" }, new object[] { "Quiz 2", "1" });
            migrationBuilder.InsertData("Quizzes", new string[] { "Title", "TeacherId" }, new object[] { "Quiz 3", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Quizzes", new string[] { "Title", "TeacherId" }, new object[] { "Quiz 1", "1" });
            migrationBuilder.DeleteData("Quizzes", new string[] { "Title", "TeacherId" }, new object[] { "Quiz 2", "1" });
            migrationBuilder.DeleteData("Quizzes", new string[] { "Title", "TeacherId" }, new object[] { "Quiz 3", "1" });
        }
    }
}

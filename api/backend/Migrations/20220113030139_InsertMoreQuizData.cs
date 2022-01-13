using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertMoreQuizData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Quizzes", "Title", "Quiz 2");
            migrationBuilder.InsertData("Quizzes", "Title", "Quiz 3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Quizzes", "Title", "Quiz 2");
            migrationBuilder.DeleteData("Quizzes", "Title", "Quiz 3");
        }
    }
}

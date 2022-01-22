using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertUserQuizData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("UserQuizzes", new string[] { "Id", "UserId", "QuizId" }, new string[] { "1", "1", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("UserQuizzes", new string[] { "Id", "UserId", "QuizId" }, new string[] { "1", "1", "1" });
        }
    }
}

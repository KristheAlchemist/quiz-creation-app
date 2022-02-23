using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertQuizQuestionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("QuizQuestions", new string[] { "QuizId", "QuestionId" }, new string[] { "1", "1" });
            migrationBuilder.InsertData("QuizQuestions", new string[] { "QuizId", "QuestionId" }, new string[] { "1", "2" });
            migrationBuilder.InsertData("QuizQuestions", new string[] { "QuizId", "QuestionId" }, new string[] { "2", "3" });
            migrationBuilder.InsertData("QuizQuestions", new string[] { "QuizId", "QuestionId" }, new string[] { "3", "4" });
            migrationBuilder.InsertData("QuizQuestions", new string[] { "QuizId", "QuestionId" }, new string[] { "1", "5" });
            migrationBuilder.InsertData("QuizQuestions", new string[] { "QuizId", "QuestionId" }, new string[] { "2", "5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("QuizQuestions", new string[] { "QuizId", "QuestionId" }, new string[] { "1", "1" });
            migrationBuilder.DeleteData("QuizQuestions", new string[] { "QuizId", "QuestionId" }, new string[] { "1", "2" });
            migrationBuilder.DeleteData("QuizQuestions", new string[] { "QuizId", "QuestionId" }, new string[] { "2", "3" });
            migrationBuilder.DeleteData("QuizQuestions", new string[] { "QuizId", "QuestionId" }, new string[] { "3", "4" });
            migrationBuilder.DeleteData("QuizQuestions", new string[] { "QuizId", "QuestionId" }, new string[] { "1", "5" });
            migrationBuilder.DeleteData("QuizQuestions", new string[] { "QuizId", "QuestionId" }, new string[] { "2", "5" });
        }
    }
}

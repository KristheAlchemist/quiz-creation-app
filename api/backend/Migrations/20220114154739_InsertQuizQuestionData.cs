using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertQuizQuestionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("QuizQuestions", new string[] { "Id", "QuizId", "QuestionId" }, new string[] { "1", "1", "1" });
            migrationBuilder.InsertData("QuizQuestions", new string[] { "Id", "QuizId", "QuestionId" }, new string[] { "2", "1", "2" });
            migrationBuilder.InsertData("QuizQuestions", new string[] { "Id", "QuizId", "QuestionId" }, new string[] { "3", "2", "3" });
            migrationBuilder.InsertData("QuizQuestions", new string[] { "Id", "QuizId", "QuestionId" }, new string[] { "4", "3", "4" });
            migrationBuilder.InsertData("QuizQuestions", new string[] { "Id", "QuizId", "QuestionId" }, new string[] { "5", "1", "5" });
            migrationBuilder.InsertData("QuizQuestions", new string[] { "Id", "QuizId", "QuestionId" }, new string[] { "6", "2", "5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("QuizQuestions", new string[] { "Id", "QuizId", "QuestionId" }, new string[] { "1", "1", "1" });
            migrationBuilder.DeleteData("QuizQuestions", new string[] { "Id", "QuizId", "QuestionId" }, new string[] { "2", "1", "2" });
            migrationBuilder.DeleteData("QuizQuestions", new string[] { "Id", "QuizId", "QuestionId" }, new string[] { "3", "2", "3" });
            migrationBuilder.DeleteData("QuizQuestions", new string[] { "Id", "QuizId", "QuestionId" }, new string[] { "4", "3", "4" });
            migrationBuilder.DeleteData("QuizQuestions", new string[] { "Id", "QuizId", "QuestionId" }, new string[] { "5", "1", "5" });
            migrationBuilder.DeleteData("QuizQuestions", new string[] { "Id", "QuizId", "QuestionId" }, new string[] { "6", "2", "5" });
        }
    }
}

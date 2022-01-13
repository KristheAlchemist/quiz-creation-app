using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertMoreQuestionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Questions", new string[] { "Id", "Text", "CorrectAnswer", "QuestionTypeId" }, new string[] { "2", "What do you call a pig that does karate?", "A pork chop", "3" });
            migrationBuilder.InsertData("Questions", new string[] { "Id", "Text", "CorrectAnswer", "QuestionTypeId" }, new string[] { "3", "Why did the bike fall over?", "It was two tired.", "3" });
            migrationBuilder.InsertData("Questions", new string[] { "Id", "Text", "CorrectAnswer", "QuestionTypeId" }, new string[] { "4", "Why did the golfer bring two pairs of pants?", "In case he got a hole in one.", "3" });
            migrationBuilder.InsertData("Questions", new string[] { "Id", "Text", "CorrectAnswer", "QuestionTypeId" }, new string[] { "5", "What do you call fake spaghetti?", "An im-pasta.", "3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Questions", new string[] { "Id", "Text", "CorrectAnswer", "QuestionTypeId" }, new string[] { "2", "What do you call a pig that does karate?", "", "3" });
            migrationBuilder.DeleteData("Questions", new string[] { "Id", "Text", "CorrectAnswer", "QuestionTypeId" }, new string[] { "3", "Why did the bike fall over?", "It was two tired.", "3" });
            migrationBuilder.DeleteData("Questions", new string[] { "Id", "Text", "CorrectAnswer", "QuestionTypeId" }, new string[] { "4", "Why did the golfer bring two pairs of pants?", "In case he got a hole in one.", "3" });
            migrationBuilder.DeleteData("Questions", new string[] { "Id", "Text", "CorrectAnswer", "QuestionTypeId" }, new string[] { "5", "What do you call fake spaghetti?", "An im-pasta.", "3" });
        }
    }
}

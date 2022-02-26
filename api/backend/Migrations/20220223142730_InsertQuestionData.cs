using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertQuestionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Questions", new string[] { "Text", "CorrectAnswer", "QuestionType" }, new object[] { "Why did the chicken cross the road?", "To get to the other side.", 1 });
            migrationBuilder.InsertData("Questions", new string[] { "Text", "CorrectAnswer", "QuestionType" }, new object[] { "What do you call a pig that does karate?", "A pork chop", 1 });
            migrationBuilder.InsertData("Questions", new string[] { "Text", "CorrectAnswer", "QuestionType" }, new object[] { "Why did the bike fall over?", "It was two tired.", 1 });
            migrationBuilder.InsertData("Questions", new string[] { "Text", "CorrectAnswer", "QuestionType" }, new object[] { "Why did the golfer bring two pairs of pants?", "In case he got a hole in one.", 1 });
            migrationBuilder.InsertData("Questions", new string[] { "Text", "CorrectAnswer", "QuestionType" }, new object[] { "What do you call fake spaghetti?", "An im-pasta.", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Questions", new string[] { "Text", "CorrectAnswer", "QuestionType" }, new object[] { "Why did the chicken cross the road?", "To get to the other side.", 1 });
            migrationBuilder.DeleteData("Questions", new string[] { "Text", "CorrectAnswer", "QuestionType" }, new object[] { "What do you call a pig that does karate?", "", 1 });
            migrationBuilder.DeleteData("Questions", new string[] { "Text", "CorrectAnswer", "QuestionType" }, new object[] { "Why did the bike fall over?", "It was two tired.", 1 });
            migrationBuilder.DeleteData("Questions", new string[] { "Text", "CorrectAnswer", "QuestionType" }, new object[] { "Why did the golfer bring two pairs of pants?", "In case he got a hole in one.", 1 });
            migrationBuilder.DeleteData("Questions", new string[] { "Text", "CorrectAnswer", "QuestionType" }, new object[] { "What do you call fake spaghetti?", "An im-pasta.", 1 });
        }
    }
}

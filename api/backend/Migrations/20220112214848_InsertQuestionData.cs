using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertQuestionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Questions", new string[] { "Id", "Text", "CorrectAnswer", "QuestionTypeId" }, new object[] { 1, "Why did the chicken cross the road?", "To get to the other side.", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Questions", new string[] { "Id", "Text", "CorrectAnswer", "QuestionTypeId" }, new object[] { 1, "Why did the chicken cross the road?", "To get to the other side.", 3 });
        }
    }
}

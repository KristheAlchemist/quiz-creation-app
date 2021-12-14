using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Question", "Text", "Why did the chicken cross the road?");
            migrationBuilder.InsertData("Question", "QuestionType", "MultipleChoice");
            migrationBuilder.InsertData("Question", "Answer", "To get to the other side.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Question", "Text", "Why did the chicken cross the road?");
            migrationBuilder.DeleteData("Question", "QuestionType", "MultipleChoice");
            migrationBuilder.DeleteData("Question", "Answer", "To get to the other side.");
        }
    }
}

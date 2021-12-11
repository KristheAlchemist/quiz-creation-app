using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Questions", "Text", "Why did the chicken cross the road?");
            migrationBuilder.InsertData("Questions", "QuestionType", "MultipleChoice");
            migrationBuilder.InsertData("Questions", "Answer", "To get to the other side.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Questions", "Text", "Why did the chicken cross the road?");
            migrationBuilder.DeleteData("Questions", "QuestionType", "MultipleChoice");
            migrationBuilder.DeleteData("Questions", "Answer", "To get to the other side.");
        }
    }
}

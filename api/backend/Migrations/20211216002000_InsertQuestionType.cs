using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertQuestionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("QuestionTypes", "Text", "MultipleChoice");
            migrationBuilder.InsertData("QuestionTypes", "Text", "TrueFalse");
            migrationBuilder.InsertData("QuestionTypes", "Text", "ShortAnswer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("QuestionTypes", "Text", "Multiple Choice");
            migrationBuilder.DeleteData("QuestionTypes", "Text", "TrueFalse");
            migrationBuilder.DeleteData("QuestionTypes", "Text", "ShortAnswer");
        }
    }
}

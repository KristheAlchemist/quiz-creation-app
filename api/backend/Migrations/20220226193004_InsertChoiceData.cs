using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertChoiceData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 1, "To not get eaten.", 1 });
            migrationBuilder.InsertData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 2, "To get to the other side.", 1 });
            migrationBuilder.InsertData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 3, "To avoid lame and outdated jokes.", 1 });
            migrationBuilder.InsertData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 4, "A pork chop.", 2 });
            migrationBuilder.InsertData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 5, "Hamurai Knight.", 2 });
            migrationBuilder.InsertData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 6, "Bacon Boarrior.", 2 });
            migrationBuilder.InsertData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 7, "Too many tequila shots before riding.", 3 });
            migrationBuilder.InsertData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 8, "Too much Rockin', not enough Rollin'.", 3 });
            migrationBuilder.InsertData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 9, "It was two tired.", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 1, "To not get eaten.", 1 });
            migrationBuilder.DeleteData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 2, "To get to the other side.", 1 });
            migrationBuilder.DeleteData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 3, "To avoid lame and outdated jokes.", 1 });
            migrationBuilder.DeleteData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 4, "A pork chop.", 2 });
            migrationBuilder.DeleteData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 5, "Hamurai Knight.", 2 });
            migrationBuilder.DeleteData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 6, "Bacon Boarrior.", 2 });
            migrationBuilder.DeleteData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 7, "Too many tequila shots before riding.", 3 });
            migrationBuilder.DeleteData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 8, "Too much Rockin', not enough Rollin'.", 3 });
            migrationBuilder.DeleteData("Choices", new string[] { "Id", "Text", "QuestionId" }, new object[] { 9, "It was two tired.", 3 });
        }
    }
}

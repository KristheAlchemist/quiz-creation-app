using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertTestPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Test", "Title", "Test 1");
            migrationBuilder.InsertData("Question", "Text", "Why did the chicken cross the road?");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Test", "Title", "Test 1");
            migrationBuilder.DeleteData("Question", "Text", "Why did the chicken cross the road?");

        }
    }
}

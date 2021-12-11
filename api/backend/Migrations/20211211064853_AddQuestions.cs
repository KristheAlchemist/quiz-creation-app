using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class AddQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsersAnswer",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question",
                table: "Tests");

            migrationBuilder.AddColumn<string>(
                name: "UsersAnswer",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

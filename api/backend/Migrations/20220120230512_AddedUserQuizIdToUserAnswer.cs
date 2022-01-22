using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class AddedUserQuizIdToUserAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_UserQuizzes_UserQuizId",
                table: "UserAnswer");

            migrationBuilder.AlterColumn<int>(
                name: "UserQuizId",
                table: "UserAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_UserQuizzes_UserQuizId",
                table: "UserAnswer",
                column: "UserQuizId",
                principalTable: "UserQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_UserQuizzes_UserQuizId",
                table: "UserAnswer");

            migrationBuilder.AlterColumn<int>(
                name: "UserQuizId",
                table: "UserAnswer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_UserQuizzes_UserQuizId",
                table: "UserAnswer",
                column: "UserQuizId",
                principalTable: "UserQuizzes",
                principalColumn: "Id");
        }
    }
}

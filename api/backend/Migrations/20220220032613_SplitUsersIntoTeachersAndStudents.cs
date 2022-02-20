using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class SplitUsersIntoTeachersAndStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfflineCourses_User_Id",
                table: "OfflineCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfflineCourses",
                table: "OfflineCourses");

            migrationBuilder.RenameTable(
                name: "OfflineCourses",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_User_Id",
                table: "Students",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_User_Id",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "OfflineCourses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfflineCourses",
                table: "OfflineCourses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfflineCourses_User_Id",
                table: "OfflineCourses",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}

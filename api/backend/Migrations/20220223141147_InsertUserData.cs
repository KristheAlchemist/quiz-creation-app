using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.InsertData("Students", new string[] { "Name", "Email" }, new object[] { "Kris Robinson", "kris@wwt.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Students", new string[] { "Name", "Email" }, new object[] { "Kris Robinson", "kris@wwt.com" });
        }
    }
}

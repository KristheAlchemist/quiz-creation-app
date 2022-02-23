using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InsertUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Teachers", "Name", "Mr. Robinson");
            migrationBuilder.InsertData("Students", "Name", "Kris Robinson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Teachers", "Name", "Mr. Robinson");
            migrationBuilder.DeleteData("Students", "Name", "Kris Robinson");
        }
    }
}

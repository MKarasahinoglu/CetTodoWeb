using Microsoft.EntityFrameworkCore.Migrations;

namespace CetTodoWeb.Data.Migrations
{
    public partial class CategoryLoginAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CetUserId",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CetUserId",
                table: "Categories",
                column: "CetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_CetUserId",
                table: "Categories",
                column: "CetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_CetUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CetUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CetUserId",
                table: "Categories");
        }
    }
}

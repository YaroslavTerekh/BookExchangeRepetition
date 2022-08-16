using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookExchange.Migrations
{
    public partial class FixedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_User_OwnerID",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Books",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_OwnerID",
                table: "Books",
                newName: "IX_Books_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_User_UserId",
                table: "Books",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_User_UserId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Books",
                newName: "OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Books_UserId",
                table: "Books",
                newName: "IX_Books_OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_User_OwnerID",
                table: "Books",
                column: "OwnerID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

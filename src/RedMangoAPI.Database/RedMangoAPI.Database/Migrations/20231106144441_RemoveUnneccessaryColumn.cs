using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedMangoAPI.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnneccessaryColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId1",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_UserId1",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ShoppingCarts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ShoppingCarts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId1",
                table: "ShoppingCarts",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId1",
                table: "ShoppingCarts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

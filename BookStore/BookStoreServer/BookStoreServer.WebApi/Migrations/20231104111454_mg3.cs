using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreServer.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_shopping_carts_users_user_id",
                table: "shopping_carts");

            migrationBuilder.DropIndex(
                name: "ix_shopping_carts_user_id",
                table: "shopping_carts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_shopping_carts_user_id",
                table: "shopping_carts",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_shopping_carts_users_user_id",
                table: "shopping_carts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}

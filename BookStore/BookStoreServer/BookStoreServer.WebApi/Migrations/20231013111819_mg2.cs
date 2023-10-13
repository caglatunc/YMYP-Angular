using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreServer.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories");

            migrationBuilder.DropIndex(
                name: "IX_BookCategories_BookId",
                table: "BookCategories");

            migrationBuilder.DropColumn(
                name: "id",
                table: "BookCategories");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories",
                columns: new[] { "BookId", "CategoryId" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverImageUrl", "CreateAt", "ISBN", "IsActive", "IsDeleted", "Price", "Quantity", "Summary", "Title" },
                values: new object[,]
                {
                    { 1, "Author 1", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9408), "ISBN 1", true, false, 10m, 10, "Summary 1", "Book 1" },
                    { 2, "Author 2", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9413), "ISBN 2", true, false, 10m, 10, "Summary 2", "Book 2" },
                    { 3, "Author 3", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9415), "ISBN 3", true, false, 10m, 10, "Summary 3", "Book 3" },
                    { 4, "Author 4", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9417), "ISBN 4", true, false, 10m, 10, "Summary 4", "Book 4" },
                    { 5, "Author 5", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9420), "ISBN 5", true, false, 10m, 10, "Summary 5", "Book 5" },
                    { 6, "Author 6", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9423), "ISBN 6", true, false, 10m, 10, "Summary 6", "Book 6" },
                    { 7, "Author 7", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9425), "ISBN 7", true, false, 10m, 10, "Summary 7", "Book 7" },
                    { 8, "Author 8", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9427), "ISBN 8", true, false, 10m, 10, "Summary 8", "Book 8" },
                    { 9, "Author 9", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9430), "ISBN 9", true, false, 10m, 10, "Summary 9", "Book 9" },
                    { 10, "Author 10", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9433), "ISBN 10", true, false, 10m, 10, "Summary 10", "Book 10" },
                    { 11, "Author 11", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9435), "ISBN 11", true, false, 10m, 10, "Summary 11", "Book 11" },
                    { 12, "Author 12", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9437), "ISBN 12", true, false, 10m, 10, "Summary 12", "Book 12" },
                    { 13, "Author 13", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9440), "ISBN 13", true, false, 10m, 10, "Summary 13", "Book 13" },
                    { 14, "Author 14", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9442), "ISBN 14", true, false, 10m, 10, "Summary 14", "Book 14" },
                    { 15, "Author 15", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9444), "ISBN 15", true, false, 10m, 10, "Summary 15", "Book 15" },
                    { 16, "Author 16", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9446), "ISBN 16", true, false, 10m, 10, "Summary 16", "Book 16" },
                    { 17, "Author 17", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9448), "ISBN 17", true, false, 10m, 10, "Summary 17", "Book 17" },
                    { 18, "Author 18", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9451), "ISBN 18", true, false, 10m, 10, "Summary 18", "Book 18" },
                    { 19, "Author 19", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9454), "ISBN 19", true, false, 10m, 10, "Summary 19", "Book 19" },
                    { 20, "Author 20", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9478), "ISBN 20", true, false, 10m, 10, "Summary 20", "Book 20" },
                    { 21, "Author 21", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9481), "ISBN 21", true, false, 10m, 10, "Summary 21", "Book 21" },
                    { 22, "Author 22", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9483), "ISBN 22", true, false, 10m, 10, "Summary 22", "Book 22" },
                    { 23, "Author 23", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9485), "ISBN 23", true, false, 10m, 10, "Summary 23", "Book 23" },
                    { 24, "Author 24", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9488), "ISBN 24", true, false, 10m, 10, "Summary 24", "Book 24" },
                    { 25, "Author 25", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9490), "ISBN 25", true, false, 10m, 10, "Summary 25", "Book 25" },
                    { 26, "Author 26", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9492), "ISBN 26", true, false, 10m, 10, "Summary 26", "Book 26" },
                    { 27, "Author 27", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9494), "ISBN 27", true, false, 10m, 10, "Summary 27", "Book 27" },
                    { 28, "Author 28", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9497), "ISBN 28", true, false, 10m, 10, "Summary 28", "Book 28" },
                    { 29, "Author 29", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9500), "ISBN 29", true, false, 10m, 10, "Summary 29", "Book 29" },
                    { 30, "Author 30", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9502), "ISBN 30", true, false, 10m, 10, "Summary 30", "Book 30" },
                    { 31, "Author 31", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9504), "ISBN 31", true, false, 10m, 10, "Summary 31", "Book 31" },
                    { 32, "Author 32", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9506), "ISBN 32", true, false, 10m, 10, "Summary 32", "Book 32" },
                    { 33, "Author 33", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9508), "ISBN 33", true, false, 10m, 10, "Summary 33", "Book 33" },
                    { 34, "Author 34", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9511), "ISBN 34", true, false, 10m, 10, "Summary 34", "Book 34" },
                    { 35, "Author 35", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9513), "ISBN 35", true, false, 10m, 10, "Summary 35", "Book 35" },
                    { 36, "Author 36", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9516), "ISBN 36", true, false, 10m, 10, "Summary 36", "Book 36" },
                    { 37, "Author 37", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9518), "ISBN 37", true, false, 10m, 10, "Summary 37", "Book 37" },
                    { 38, "Author 38", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9520), "ISBN 38", true, false, 10m, 10, "Summary 38", "Book 38" },
                    { 39, "Author 39", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9522), "ISBN 39", true, false, 10m, 10, "Summary 39", "Book 39" },
                    { 40, "Author 40", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9524), "ISBN 40", true, false, 10m, 10, "Summary 40", "Book 40" },
                    { 41, "Author 41", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9526), "ISBN 41", true, false, 10m, 10, "Summary 41", "Book 41" },
                    { 42, "Author 42", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9529), "ISBN 42", true, false, 10m, 10, "Summary 42", "Book 42" },
                    { 43, "Author 43", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9531), "ISBN 43", true, false, 10m, 10, "Summary 43", "Book 43" },
                    { 44, "Author 44", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9533), "ISBN 44", true, false, 10m, 10, "Summary 44", "Book 44" },
                    { 45, "Author 45", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9535), "ISBN 45", true, false, 10m, 10, "Summary 45", "Book 45" },
                    { 46, "Author 46", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9537), "ISBN 46", true, false, 10m, 10, "Summary 46", "Book 46" },
                    { 47, "Author 47", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9540), "ISBN 47", true, false, 10m, 10, "Summary 47", "Book 47" },
                    { 48, "Author 48", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9542), "ISBN 48", true, false, 10m, 10, "Summary 48", "Book 48" },
                    { 49, "Author 49", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9564), "ISBN 49", true, false, 10m, 10, "Summary 49", "Book 49" },
                    { 50, "Author 50", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9567), "ISBN 50", true, false, 10m, 10, "Summary 50", "Book 50" },
                    { 51, "Author 51", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9569), "ISBN 51", true, false, 10m, 10, "Summary 51", "Book 51" },
                    { 52, "Author 52", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9571), "ISBN 52", true, false, 10m, 10, "Summary 52", "Book 52" },
                    { 53, "Author 53", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9573), "ISBN 53", true, false, 10m, 10, "Summary 53", "Book 53" },
                    { 54, "Author 54", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9576), "ISBN 54", true, false, 10m, 10, "Summary 54", "Book 54" },
                    { 55, "Author 55", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9578), "ISBN 55", true, false, 10m, 10, "Summary 55", "Book 55" },
                    { 56, "Author 56", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9580), "ISBN 56", true, false, 10m, 10, "Summary 56", "Book 56" },
                    { 57, "Author 57", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9582), "ISBN 57", true, false, 10m, 10, "Summary 57", "Book 57" },
                    { 58, "Author 58", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9584), "ISBN 58", true, false, 10m, 10, "Summary 58", "Book 58" },
                    { 59, "Author 59", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9586), "ISBN 59", true, false, 10m, 10, "Summary 59", "Book 59" },
                    { 60, "Author 60", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9589), "ISBN 60", true, false, 10m, 10, "Summary 60", "Book 60" },
                    { 61, "Author 61", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9591), "ISBN 61", true, false, 10m, 10, "Summary 61", "Book 61" },
                    { 62, "Author 62", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9593), "ISBN 62", true, false, 10m, 10, "Summary 62", "Book 62" },
                    { 63, "Author 63", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9595), "ISBN 63", true, false, 10m, 10, "Summary 63", "Book 63" },
                    { 64, "Author 64", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9597), "ISBN 64", true, false, 10m, 10, "Summary 64", "Book 64" },
                    { 65, "Author 65", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9599), "ISBN 65", true, false, 10m, 10, "Summary 65", "Book 65" },
                    { 66, "Author 66", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9602), "ISBN 66", true, false, 10m, 10, "Summary 66", "Book 66" },
                    { 67, "Author 67", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9604), "ISBN 67", true, false, 10m, 10, "Summary 67", "Book 67" },
                    { 68, "Author 68", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9607), "ISBN 68", true, false, 10m, 10, "Summary 68", "Book 68" },
                    { 69, "Author 69", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9609), "ISBN 69", true, false, 10m, 10, "Summary 69", "Book 69" },
                    { 70, "Author 70", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9611), "ISBN 70", true, false, 10m, 10, "Summary 70", "Book 70" },
                    { 71, "Author 71", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9613), "ISBN 71", true, false, 10m, 10, "Summary 71", "Book 71" },
                    { 72, "Author 72", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9615), "ISBN 72", true, false, 10m, 10, "Summary 72", "Book 72" },
                    { 73, "Author 73", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9617), "ISBN 73", true, false, 10m, 10, "Summary 73", "Book 73" },
                    { 74, "Author 74", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9620), "ISBN 74", true, false, 10m, 10, "Summary 74", "Book 74" },
                    { 75, "Author 75", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9622), "ISBN 75", true, false, 10m, 10, "Summary 75", "Book 75" },
                    { 76, "Author 76", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9644), "ISBN 76", true, false, 10m, 10, "Summary 76", "Book 76" },
                    { 77, "Author 77", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9647), "ISBN 77", true, false, 10m, 10, "Summary 77", "Book 77" },
                    { 78, "Author 78", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9649), "ISBN 78", true, false, 10m, 10, "Summary 78", "Book 78" },
                    { 79, "Author 79", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9651), "ISBN 79", true, false, 10m, 10, "Summary 79", "Book 79" },
                    { 80, "Author 80", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9653), "ISBN 80", true, false, 10m, 10, "Summary 80", "Book 80" },
                    { 81, "Author 81", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9656), "ISBN 81", true, false, 10m, 10, "Summary 81", "Book 81" },
                    { 82, "Author 82", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9658), "ISBN 82", true, false, 10m, 10, "Summary 82", "Book 82" },
                    { 83, "Author 83", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9660), "ISBN 83", true, false, 10m, 10, "Summary 83", "Book 83" },
                    { 84, "Author 84", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9662), "ISBN 84", true, false, 10m, 10, "Summary 84", "Book 84" },
                    { 85, "Author 85", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9664), "ISBN 85", true, false, 10m, 10, "Summary 85", "Book 85" },
                    { 86, "Author 86", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9666), "ISBN 86", true, false, 10m, 10, "Summary 86", "Book 86" },
                    { 87, "Author 87", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9669), "ISBN 87", true, false, 10m, 10, "Summary 87", "Book 87" },
                    { 88, "Author 88", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9671), "ISBN 88", true, false, 10m, 10, "Summary 88", "Book 88" },
                    { 89, "Author 89", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9673), "ISBN 89", true, false, 10m, 10, "Summary 89", "Book 89" },
                    { 90, "Author 90", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9675), "ISBN 90", true, false, 10m, 10, "Summary 90", "Book 90" },
                    { 91, "Author 91", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9678), "ISBN 91", true, false, 10m, 10, "Summary 91", "Book 91" },
                    { 92, "Author 92", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9680), "ISBN 92", true, false, 10m, 10, "Summary 92", "Book 92" },
                    { 93, "Author 93", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9682), "ISBN 93", true, false, 10m, 10, "Summary 93", "Book 93" },
                    { 94, "Author 94", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9684), "ISBN 94", true, false, 10m, 10, "Summary 94", "Book 94" },
                    { 95, "Author 95", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9686), "ISBN 95", true, false, 10m, 10, "Summary 95", "Book 95" },
                    { 96, "Author 96", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9688), "ISBN 96", true, false, 10m, 10, "Summary 96", "Book 96" },
                    { 97, "Author 97", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9691), "ISBN 97", true, false, 10m, 10, "Summary 97", "Book 97" },
                    { 98, "Author 98", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9693), "ISBN 98", true, false, 10m, 10, "Summary 98", "Book 98" },
                    { 99, "Author 99", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9695), "ISBN 99", true, false, 10m, 10, "Summary 99", "Book 99" },
                    { 100, "Author 100", "https://m.media-amazon.com/images/I/71Qde+ZerdL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 10, 13, 14, 18, 19, 602, DateTimeKind.Local).AddTicks(9697), "ISBN 100", true, false, 10m, 10, "Summary 100", "Book 100" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, true, false, "Category 1" },
                    { 2, true, false, "Category 2" },
                    { 3, true, false, "Category 3" },
                    { 4, true, false, "Category 4" },
                    { 5, true, false, "Category 5" },
                    { 6, true, false, "Category 6" },
                    { 7, true, false, "Category 7" },
                    { 8, true, false, "Category 8" },
                    { 9, true, false, "Category 9" },
                    { 10, true, false, "Category 10" }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 8 },
                    { 2, 10 },
                    { 3, 6 },
                    { 4, 10 },
                    { 5, 9 },
                    { 6, 4 },
                    { 7, 4 },
                    { 8, 9 },
                    { 9, 2 },
                    { 10, 1 },
                    { 11, 7 },
                    { 12, 7 },
                    { 13, 10 },
                    { 14, 8 },
                    { 15, 9 },
                    { 16, 6 },
                    { 17, 9 },
                    { 18, 9 },
                    { 19, 1 },
                    { 20, 10 },
                    { 21, 7 },
                    { 22, 3 },
                    { 23, 10 },
                    { 24, 10 },
                    { 25, 10 },
                    { 26, 10 },
                    { 27, 1 },
                    { 28, 5 },
                    { 29, 3 },
                    { 30, 9 },
                    { 31, 6 },
                    { 32, 9 },
                    { 33, 9 },
                    { 34, 10 },
                    { 35, 6 },
                    { 36, 8 },
                    { 37, 10 },
                    { 38, 10 },
                    { 39, 9 },
                    { 40, 3 },
                    { 41, 3 },
                    { 42, 2 },
                    { 43, 6 },
                    { 44, 3 },
                    { 45, 5 },
                    { 46, 6 },
                    { 47, 3 },
                    { 48, 1 },
                    { 49, 5 },
                    { 50, 5 },
                    { 51, 2 },
                    { 52, 10 },
                    { 53, 2 },
                    { 54, 5 },
                    { 55, 7 },
                    { 56, 5 },
                    { 57, 9 },
                    { 58, 10 },
                    { 59, 5 },
                    { 60, 7 },
                    { 61, 4 },
                    { 62, 10 },
                    { 63, 10 },
                    { 64, 2 },
                    { 65, 6 },
                    { 66, 8 },
                    { 67, 8 },
                    { 68, 3 },
                    { 69, 8 },
                    { 70, 2 },
                    { 71, 8 },
                    { 72, 10 },
                    { 73, 2 },
                    { 74, 8 },
                    { 75, 2 },
                    { 76, 2 },
                    { 77, 7 },
                    { 78, 2 },
                    { 79, 8 },
                    { 80, 3 },
                    { 81, 7 },
                    { 82, 10 },
                    { 83, 1 },
                    { 84, 2 },
                    { 85, 10 },
                    { 86, 9 },
                    { 87, 6 },
                    { 88, 1 },
                    { 89, 6 },
                    { 90, 8 },
                    { 91, 6 },
                    { 92, 7 },
                    { 93, 6 },
                    { 94, 5 },
                    { 95, 3 },
                    { 96, 1 },
                    { 97, 4 },
                    { 98, 5 },
                    { 99, 7 },
                    { 100, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_CategoryId",
                table: "BookCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategories_Categories_CategoryId",
                table: "BookCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategories_Categories_CategoryId",
                table: "BookCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories");

            migrationBuilder.DropIndex(
                name: "IX_BookCategories_CategoryId",
                table: "BookCategories");

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 11, 7 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 12, 7 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 15, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 16, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 17, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 18, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 20, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 21, 7 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 22, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 23, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 24, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 26, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 27, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 28, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 30, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 32, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 33, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 34, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 35, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 36, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 37, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 38, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 39, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 40, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 41, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 42, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 43, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 44, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 45, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 48, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 49, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 50, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 51, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 52, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 53, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 54, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 55, 7 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 56, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 57, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 58, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 59, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 60, 7 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 61, 4 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 62, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 63, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 64, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 65, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 66, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 67, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 68, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 69, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 70, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 71, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 72, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 73, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 74, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 75, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 76, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 77, 7 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 78, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 79, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 80, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 81, 7 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 82, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 83, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 84, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 85, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 86, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 87, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 88, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 89, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 90, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 91, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 92, 7 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 93, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 94, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 95, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 96, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 97, 4 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 98, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 99, 7 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 100, 4 });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "BookCategories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_BookId",
                table: "BookCategories",
                column: "BookId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class addSeederLivros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "livros",
                columns: new[] { "Id", "Autor", "Estoque", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, "Autor 1", true, "Livro 1", 19.989999771118164 },
                    { 2, "Autor 2", false, "Livro 2", 29.989999771118164 },
                    { 3, "Autor 3", true, "Livro 3", 39.990001678466797 },
                    { 4, "Autor 4", false, "Livro 4", 49.990001678466797 },
                    { 5, "Autor 5", true, "Livro 5", 59.990001678466797 },
                    { 6, "Autor 6", false, "Livro 6", 69.989997863769531 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}

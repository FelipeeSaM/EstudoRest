using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class addSeederLivros2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 1,
                column: "Preco",
                value: 18.989999999999998);

            migrationBuilder.UpdateData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 2,
                column: "Preco",
                value: 28.989999999999998);

            migrationBuilder.UpdateData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 3,
                column: "Preco",
                value: 38.990000000000002);

            migrationBuilder.UpdateData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 4,
                column: "Preco",
                value: 48.990000000000002);

            migrationBuilder.UpdateData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 5,
                column: "Preco",
                value: 58.990000000000002);

            migrationBuilder.UpdateData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 6,
                column: "Preco",
                value: 68.989999999999995);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 1,
                column: "Preco",
                value: 19.989999771118164);

            migrationBuilder.UpdateData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 2,
                column: "Preco",
                value: 29.989999771118164);

            migrationBuilder.UpdateData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 3,
                column: "Preco",
                value: 39.990001678466797);

            migrationBuilder.UpdateData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 4,
                column: "Preco",
                value: 49.990001678466797);

            migrationBuilder.UpdateData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 5,
                column: "Preco",
                value: 59.990001678466797);

            migrationBuilder.UpdateData(
                table: "livros",
                keyColumn: "Id",
                keyValue: 6,
                column: "Preco",
                value: 69.989997863769531);
        }
    }
}

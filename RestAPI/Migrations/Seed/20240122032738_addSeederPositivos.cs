using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class addSeederPositivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "pessoas",
                columns: new[] { "Id", "Endereco", "Genero", "PrimeiroNome", "UltimoNome" },
                values: new object[,]
                {
                    { 1, "Rua A", "Masculino", "João", "Silva" },
                    { 2, "Rua B", "Feminino", "Maria", "Santos" },
                    { 3, "Rua C", "Masculino", "Pedro", "Oliveira" },
                    { 4, "Rua D", "Feminino", "Ana", "Costa" },
                    { 5, "Rua E", "Masculino", "Lucas", "Pereira" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "pessoas",
                columns: new[] { "Id", "Endereco", "Genero", "PrimeiroNome", "UltimoNome" },
                values: new object[,]
                {
                    { -5, "Rua E", "Masculino", "Lucas", "Pereira" },
                    { -4, "Rua D", "Feminino", "Ana", "Costa" },
                    { -3, "Rua C", "Masculino", "Pedro", "Oliveira" },
                    { -2, "Rua B", "Feminino", "Maria", "Santos" },
                    { -1, "Rua A", "Masculino", "João", "Silva" }
                });
        }
    }
}

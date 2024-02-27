using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class add_coluna_ativo_pessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Ativo",
                table: "pessoas",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ativo",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ativo",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Ativo",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Ativo",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 5,
                column: "Ativo",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RefreshTokenExpiryTime",
                value: new DateTime(2024, 2, 27, 3, 37, 17, 586, DateTimeKind.Local).AddTicks(8843));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "pessoas");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RefreshTokenExpiryTime",
                value: new DateTime(2024, 2, 15, 19, 9, 54, 254, DateTimeKind.Local).AddTicks(9482));
        }
    }
}

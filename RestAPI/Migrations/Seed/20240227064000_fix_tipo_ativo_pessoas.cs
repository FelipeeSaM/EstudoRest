using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class fix_tipo_ativo_pessoas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "pessoas",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.UpdateData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ativo",
                value: false);

            migrationBuilder.UpdateData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ativo",
                value: false);

            migrationBuilder.UpdateData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Ativo",
                value: false);

            migrationBuilder.UpdateData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Ativo",
                value: false);

            migrationBuilder.UpdateData(
                table: "pessoas",
                keyColumn: "Id",
                keyValue: 5,
                column: "Ativo",
                value: false);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RefreshTokenExpiryTime",
                value: new DateTime(2024, 2, 27, 3, 40, 0, 878, DateTimeKind.Local).AddTicks(5612));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Ativo",
                table: "pessoas",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

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
    }
}

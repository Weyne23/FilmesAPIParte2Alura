using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999998,
                column: "ConcurrencyStamp",
                value: "94413c5f-e64a-4b15-9715-477b6177e02e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "a659178e-e35a-4080-ac54-e10c2e8a1aaf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8df7398e-4881-4ecb-a5ba-2e33a50f521d", "AQAAAAEAACcQAAAAEPiG0MAAU5ST2LcbLG9c47VMSOgr5U29Yl7p20xg6kqanIUFzx6QDvMwMiRu7wRA4Q==", "3c12dbe6-a587-456d-89da-7185d68ec94c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999998,
                column: "ConcurrencyStamp",
                value: "bd22d113-69a7-4712-b031-5afa54907532");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "5cf6b07d-428e-43a1-bc85-cb82281de460");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04100193-acf8-4d83-ac07-61609e7af80d", "AQAAAAEAACcQAAAAEBNCg2MXpDnPsIy7JGonnJLYg26TuKMzXaBERzb5u6QtcyStgbd4XtxHoEmkM3JdOw==", "29f906d2-1510-48b6-9f54-2e7ab206080e" });
        }
    }
}

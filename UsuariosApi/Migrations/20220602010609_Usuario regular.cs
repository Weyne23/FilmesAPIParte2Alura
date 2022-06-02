using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class Usuarioregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "5cf6b07d-428e-43a1-bc85-cb82281de460");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 999998, "bd22d113-69a7-4712-b031-5afa54907532", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04100193-acf8-4d83-ac07-61609e7af80d", "AQAAAAEAACcQAAAAEBNCg2MXpDnPsIy7JGonnJLYg26TuKMzXaBERzb5u6QtcyStgbd4XtxHoEmkM3JdOw==", "29f906d2-1510-48b6-9f54-2e7ab206080e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "035cf156-2951-471e-8027-7147de5149c7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a2cd831-6f11-4ff3-918c-c4062e27e866", "AQAAAAEAACcQAAAAEOqudXe5KaJSSR3B64wF3c6VXFTMbnXs5EUxydabtTDqFA4MYaEHOYYa54YxtAhMBA==", "dd1a8db2-954c-41db-b328-fd6ffab14bc3" });
        }
    }
}

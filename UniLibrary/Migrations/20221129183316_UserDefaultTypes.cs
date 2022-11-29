using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UserDefaultTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 1,
                column: "Availability",
                value: true);

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 2,
                column: "Availability",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "Type",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 1,
                column: "Availability",
                value: (sbyte)1);

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "ID",
                keyValue: 2,
                column: "Availability",
                value: (sbyte)1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "Type",
                value: 0);
        }
    }
}

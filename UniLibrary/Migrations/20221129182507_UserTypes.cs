using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UserTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "Password", "Type" },
                values: new object[] { "$2a$11$78t2sJGKxrsB9PP2cJWUuO1GvhRJoV2nFmMj95HzIuO4gk1envFu6", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Password", "Type" },
                values: new object[] { "$2a$11$Igdtf.xsMYZHayTNyBjxBei3OE7vKXPsuHcxbnfcHWyMEwpa8GkCa", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Password", "Type" },
                values: new object[] { "$2a$11$5VoUc47EDdqHtTiVha2r6eASOJvEJAanyKt.iXAicbBGOUOsXikOO", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Password", "Type" },
                values: new object[] { "$2a$11$N8oNxha16C13c5GXXLpdM.iphqpjJfN1NXVquhIkZyHdhrip9VExa", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Password", "Type" },
                values: new object[] { "$2a$11$nVN067GCsOgSUO//7kY64eNk/PAvsGcqLS1YUrNmYdiGuR8hi1N5C", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Users");

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
                column: "Password",
                value: "Password1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "Password",
                value: "Password2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                column: "Password",
                value: "Password3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4,
                column: "Password",
                value: "Password4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "Password",
                value: "Password5");
        }
    }
}

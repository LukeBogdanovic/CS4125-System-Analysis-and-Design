using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersCreatedTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Loans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StudentID = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 1,
                column: "UserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 2,
                column: "UserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 3,
                column: "UserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 4,
                column: "UserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 5,
                column: "UserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 6,
                column: "UserID",
                value: null);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "EmailAddress", "Name", "Password", "StudentID" },
                values: new object[,]
                {
                    { 1, null, "Daniel Graham", null, "19855666" },
                    { 2, null, "Eric Howell", null, "19555661" },
                    { 3, null, "Patricia Lebsack", null, "19555662" },
                    { 4, null, "Kalle Runolfsdottir", null, "19555663" },
                    { 5, null, "Linus Reichert", null, "19555664" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserID",
                table: "Loans",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_UserID",
                table: "Loans",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_UserID",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Loans_UserID",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Loans");
        }
    }
}

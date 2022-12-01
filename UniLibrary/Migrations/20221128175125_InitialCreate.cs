using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ComNum = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OS = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Availability = table.Column<bool>(type: "tinyint(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "BookDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ISBN = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookDetails_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Fee = table.Column<double>(type: "double", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanID);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookCopies",
                columns: table => new
                {
                    BookCopyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DetailsID = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopies", x => x.BookCopyID);
                    table.ForeignKey(
                        name: "FK_BookCopies_BookDetails_DetailsID",
                        column: x => x.DetailsID,
                        principalTable: "BookDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookCopyLoans",
                columns: table => new
                {
                    BookCopyID = table.Column<int>(type: "int", nullable: false),
                    LoanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopyLoans", x => new { x.BookCopyID, x.LoanID });
                    table.ForeignKey(
                        name: "FK_BookCopyLoans_BookCopies_BookCopyID",
                        column: x => x.BookCopyID,
                        principalTable: "BookCopies",
                        principalColumn: "BookCopyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCopyLoans_Loans_LoanID",
                        column: x => x.LoanID,
                        principalTable: "Loans",
                        principalColumn: "LoanID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Laurelli Rolf" },
                    { 2, "Jordan B Peterson" },
                    { 3, "Annmarie Palm" },
                    { 4, "Dale Carnegie" },
                    { 5, "Bo Gustafsson" },
                    { 6, "Brian Tracy " },
                    { 7, "Stephen Denning" },
                    { 8, "Geoff Watts" },
                    { 9, "David J Anderson" },
                    { 10, "Rashina Hoda" },
                    { 11, "William Shakespeare" },
                    { 12, "Villiam Skakspjut" },
                    { 13, "Robert C. Martin" }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanID", "DueDate", "Fee", "MemberID", "ReturnDate", "StartDate", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 3, new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 24.0, 1, new DateTime(2022, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 2, new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

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

            migrationBuilder.InsertData(
                table: "BookDetails",
                columns: new[] { "ID", "AuthorID", "Description", "ISBN", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Arguably Shakespeare's greatest tragedy", "1472518381", "Hamlet" },
                    { 2, 1, "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all.", "9780141012292", "King Lear" },
                    { 3, 2, "An intense drama of love, deception, jealousy and destruction.", "1853260185", "Othello" },
                    { 4, 4, "I Affärsmannaskap har Rolf Laurelli summerat sin långa erfarenhet av konsten att göra affärer. Med boken hoppas han kunna locka fram dina affärsinstinkter.", "9789147107483", "Affärsmannaskap för ingenjörer, jurister och alla andra specialister" },
                    { 5, 5, "12 Rules for Life offers a deeply rewarding antidote to the chaos in our lives: eternal truths applied to our modern problems. ", "9780345816023", "12 Rules For Life " },
                    { 6, 6, "Denna eminenta bok handlar om hur man ska behandla sina affärskontakter för att de ska känna sig trygga med dig som affärspartner. ", "9789147122103", "Business behavior" },
                    { 7, 7, "Dale Carnegie had an understanding of human nature that will never be outdated. Financial success, Carnegie believed, is due 15 percent to professional knowledge and 85 percent to the ability to express ideas, to assume leadership, and to arouse enthusiasm among people.", "9781439199190", "How to Win Friends and Influence People" },
                    { 8, 8, "I Affärsmannaskap har Rolf Laurelli summerat sin långa erfarenhet av konsten att göra affärer. Med boken hoppas han kunna locka fram dina affärsinstinkter.", "9789186293321", "Förhandla : från strikta regler till dirty tricks" },
                    { 9, 9, "Tracy teaches readers how to utilize the six key negotiating styles ", "9780814433195", "Negotiation " },
                    { 10, 10, "The basics of being a ScrumMaster are fairly straightforward: Facilitate the Scrum process and remove impediments. ", "9780957587403", "Scrum Mastery " },
                    { 11, 11, "Optimize the effectiveness of your business, to produce fit-for-purpose products and services that delight your customers, making them loyal to your brand and increasing your share, revenues and margins.", "9780984521401", "Kanban " },
                    { 12, 12, "This  book constitutes the research workshops, doctoral symposium and panel summaries presented at the 20th International Conference on Agile Software Development", "9783030301255", " Agile Processes in Software Engineering and Extreme Programming" },
                    { 13, 13, "The Age of Agile helps readers master the three laws of Agile Management (team, customer, network)", "9780814439098", "THE AGE OF AGILE " }
                });

            migrationBuilder.InsertData(
                table: "BookCopies",
                columns: new[] { "BookCopyID", "DetailsID", "IsAvailable" },
                values: new object[,]
                {
                    { 1, 1, true },
                    { 2, 2, false },
                    { 3, 3, false },
                    { 4, 4, true },
                    { 5, 5, true },
                    { 6, 6, false },
                    { 7, 7, true },
                    { 9, 12, true },
                    { 10, 12, true },
                    { 11, 5, true },
                    { 12, 4, true },
                    { 13, 8, true },
                    { 14, 1, true },
                    { 15, 7, true },
                    { 16, 11, true },
                    { 17, 11, true },
                    { 18, 2, true },
                    { 19, 9, true },
                    { 20, 9, true },
                    { 21, 13, true },
                    { 22, 5, true },
                    { 24, 10, true },
                    { 25, 10, true },
                    { 26, 13, true },
                    { 27, 13, true }
                });

            migrationBuilder.InsertData(
                table: "BookCopyLoans",
                columns: new[] { "BookCopyID", "LoanID" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 4 },
                    { 4, 1 },
                    { 6, 6 },
                    { 7, 2 },
                    { 12, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_DetailsID",
                table: "BookCopies",
                column: "DetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopyLoans_LoanID",
                table: "BookCopyLoans",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_BookDetails_AuthorID",
                table: "BookDetails",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserID",
                table: "Loans",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCopyLoans");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "BookCopies");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "BookDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}

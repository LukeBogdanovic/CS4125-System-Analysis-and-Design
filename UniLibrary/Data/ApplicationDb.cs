using Microsoft.EntityFrameworkCore;
using UniLibrary.Models;
using UniLibrary.Factories;
using UniLibrary.Models.RoomFunctionalities;

namespace UniLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BookDetails>? BookDetails { get; set; }
        public DbSet<BookCopyLoan>? BookCopyLoans { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<BookCopy>? BookCopies { get; set; }
        public DbSet<Loan>? Loans { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Computer>? Computers { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureBookDetails(modelBuilder);
            ConfigureAuthor(modelBuilder);
            ConfigureBookCopyLoan(modelBuilder);
            ConfigureComputer(modelBuilder);
            ConfigureRooms(modelBuilder);
            ConfigureFunctionality(modelBuilder);
            ConfigureReservations(modelBuilder);
            SeedDatabase(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public static void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                            new Author { ID = 1, Name = "Laurelli Rolf" },
                            new Author { ID = 2, Name = "Jordan B Peterson" },
                            new Author { ID = 3, Name = "Annmarie Palm" },
                            new Author { ID = 4, Name = "Dale Carnegie" },
                            new Author { ID = 5, Name = "Bo Gustafsson" },
                            new Author { ID = 6, Name = "Brian Tracy " },
                            new Author { ID = 7, Name = "Stephen Denning" },
                            new Author { ID = 8, Name = "Geoff Watts" },
                            new Author { ID = 9, Name = "David J Anderson" },
                            new Author { ID = 10, Name = "Rashina Hoda" },
                            new Author { ID = 11, Name = "William Shakespeare" },
                            new Author { ID = 12, Name = "Villiam Skakspjut" },
                            new Author { ID = 13, Name = "Robert C. Martin" }
                            );
            modelBuilder.Entity<BookDetails>().HasData(
                new BookDetails
                {
                    ID = 1,
                    AuthorID = 1,
                    Title = "Hamlet",
                    ISBN = "1472518381",
                    Description = "Arguably Shakespeare's greatest tragedy"
                },
                new BookDetails
                {
                    ID = 2,
                    AuthorID = 1,
                    Title = "King Lear",
                    ISBN = "9780141012292",
                    Description = "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all."
                },
                new BookDetails
                {
                    ID = 3,
                    AuthorID = 2,
                    Title = "Othello",
                    ISBN = "1853260185",
                    Description = "An intense drama of love, deception, jealousy and destruction."
                },
                new BookDetails
                {
                    ID = 4,
                    ISBN = "9789147107483",
                    Title = "Aff??rsmannaskap f??r ingenj??rer, jurister och alla andra specialister",
                    Description = "I Aff??rsmannaskap har Rolf Laurelli summerat sin l??nga erfarenhet av konsten att g??ra aff??rer. Med boken hoppas han kunna locka fram dina aff??rsinstinkter.",
                    AuthorID = 4,
                },
                new BookDetails
                {
                    ID = 5,
                    ISBN = "9780345816023",
                    Title = "12 Rules For Life ",
                    Description = "12 Rules for Life offers a deeply rewarding antidote to the chaos in our lives: eternal truths applied to our modern problems. ",
                    AuthorID = 5,
                },
                new BookDetails
                {
                    ID = 6,
                    ISBN = "9789147122103",
                    Title = "Business behavior",
                    Description = "Denna eminenta bok handlar om hur man ska behandla sina aff??rskontakter f??r att de ska k??nna sig trygga med dig som aff??rspartner. ",
                    AuthorID = 6,
                },
                new BookDetails
                {
                    ID = 7,
                    ISBN = "9781439199190",
                    Title = "How to Win Friends and Influence People",
                    Description = "Dale Carnegie had an understanding of human nature that will never be outdated. Financial success, Carnegie believed, is due 15 percent to professional knowledge and 85 percent to the ability to express ideas, to assume leadership, and to arouse enthusiasm among people.",
                    AuthorID = 7,
                },
                new BookDetails
                {
                    ID = 8,
                    ISBN = "9789186293321",
                    Title = "F??rhandla : fr??n strikta regler till dirty tricks",
                    Description = "I Aff??rsmannaskap har Rolf Laurelli summerat sin l??nga erfarenhet av konsten att g??ra aff??rer. Med boken hoppas han kunna locka fram dina aff??rsinstinkter.",
                    AuthorID = 8,
                },
                new BookDetails
                {
                    ID = 9,
                    ISBN = "9780814433195",
                    Title = "Negotiation ",
                    Description = "Tracy teaches readers how to utilize the six key negotiating styles ",
                    AuthorID = 9,
                },
                new BookDetails
                {
                    ID = 13,
                    ISBN = "9780814439098",
                    Title = "THE AGE OF AGILE ",
                    Description = "The Age of Agile helps readers master the three laws of Agile Management (team, customer, network)",
                    AuthorID = 13,
                },
                new BookDetails
                {
                    ID = 10,
                    ISBN = "9780957587403",
                    Title = "Scrum Mastery ",
                    Description = "The basics of being a ScrumMaster are fairly straightforward: Facilitate the Scrum process and remove impediments. ",
                    AuthorID = 10,
                },
                new BookDetails
                {
                    ID = 11,
                    ISBN = "9780984521401",
                    Title = "Kanban ",
                    Description = "Optimize the effectiveness of your business, to produce fit-for-purpose products and services that delight your customers, making them loyal to your brand and increasing your share, revenues and margins.",
                    AuthorID = 11,
                },
                new BookDetails
                {
                    ID = 12,
                    ISBN = "9783030301255",
                    Title = " Agile Processes in Software Engineering and Extreme Programming",
                    Description = "This  book constitutes the research workshops, doctoral symposium and panel summaries presented at the 20th International Conference on Agile Software Development",
                    AuthorID = 12,
                }

                );

            modelBuilder.Entity<Loan>().HasData(
                new Loan { LoanID = 1, UserID = 3, StartDate = new DateTime(2022, 1, 5), DueDate = new DateTime(2022, 1, 19), ReturnDate = new DateTime(2022, 1, 19), Fee = 0 },
                new Loan { LoanID = 2, UserID = 1, StartDate = new DateTime(2022, 1, 19), DueDate = new DateTime(2022, 2, 2), ReturnDate = new DateTime(2022, 2, 6), Fee = 24 },
                new Loan { LoanID = 3, UserID = 2, StartDate = new DateTime(2022, 1, 3), DueDate = new DateTime(2022, 1, 17), ReturnDate = new DateTime(2022, 1, 16), Fee = 0 },
                new Loan { LoanID = 4, UserID = 2, StartDate = new DateTime(2022, 1, 30), DueDate = new DateTime(2022, 2, 13) },
                new Loan { LoanID = 5, UserID = 4, StartDate = new DateTime(2022, 1, 29), DueDate = new DateTime(2022, 2, 12) },
                new Loan { LoanID = 6, UserID = 5, StartDate = new DateTime(2022, 3, 2), DueDate = new DateTime(2022, 3, 16) }
            );
            modelBuilder.Entity<BookCopy>().HasData(
                new BookCopy { BookCopyID = 1, DetailsID = 1, IsAvailable = true },
                new BookCopy { BookCopyID = 2, DetailsID = 2, IsAvailable = false },
                new BookCopy { BookCopyID = 3, DetailsID = 3, IsAvailable = false },
                new BookCopy { BookCopyID = 4, DetailsID = 4, IsAvailable = true },
                new BookCopy { BookCopyID = 5, DetailsID = 5, IsAvailable = true },
                new BookCopy { BookCopyID = 6, DetailsID = 6, IsAvailable = false },
                new BookCopy { BookCopyID = 7, DetailsID = 7, IsAvailable = true },
                new BookCopy { BookCopyID = 9, DetailsID = 12, IsAvailable = true },
                new BookCopy { BookCopyID = 10, DetailsID = 12, IsAvailable = true },
                new BookCopy { BookCopyID = 11, DetailsID = 5, IsAvailable = true },
                new BookCopy { BookCopyID = 12, DetailsID = 4, IsAvailable = true },
                new BookCopy { BookCopyID = 13, DetailsID = 8, IsAvailable = true },
                new BookCopy { BookCopyID = 14, DetailsID = 1, IsAvailable = true },
                new BookCopy { BookCopyID = 15, DetailsID = 7, IsAvailable = true },
                new BookCopy { BookCopyID = 16, DetailsID = 11, IsAvailable = true },
                new BookCopy { BookCopyID = 17, DetailsID = 11, IsAvailable = true },
                new BookCopy { BookCopyID = 18, DetailsID = 2, IsAvailable = true },
                new BookCopy { BookCopyID = 19, DetailsID = 9, IsAvailable = true },
                new BookCopy { BookCopyID = 20, DetailsID = 9, IsAvailable = true },
                new BookCopy { BookCopyID = 21, DetailsID = 13, IsAvailable = true },
                new BookCopy { BookCopyID = 22, DetailsID = 5, IsAvailable = true },
                new BookCopy { BookCopyID = 24, DetailsID = 10, IsAvailable = true },
                new BookCopy { BookCopyID = 25, DetailsID = 10, IsAvailable = true },
                new BookCopy { BookCopyID = 26, DetailsID = 13, IsAvailable = true },
                new BookCopy { BookCopyID = 27, DetailsID = 13, IsAvailable = true }
            );
            modelBuilder.Entity<BookCopyLoan>().HasData(
                new BookCopyLoan { BookCopyID = 4, LoanID = 1 },
                new BookCopyLoan { BookCopyID = 1, LoanID = 2 },
                new BookCopyLoan { BookCopyID = 2, LoanID = 3 },
                new BookCopyLoan { BookCopyID = 3, LoanID = 4 },
                new BookCopyLoan { BookCopyID = 6, LoanID = 6 },
                new BookCopyLoan { BookCopyID = 2, LoanID = 5 },
                new BookCopyLoan { BookCopyID = 3, LoanID = 1 },
                new BookCopyLoan { BookCopyID = 12, LoanID = 1 },
                new BookCopyLoan { BookCopyID = 7, LoanID = 2 }
            );
            modelBuilder.Entity<User>().HasData(
                new User { ID = 1, StudentID = "19855666", Name = "Daniel Graham", Password = "$2a$11$78t2sJGKxrsB9PP2cJWUuO1GvhRJoV2nFmMj95HzIuO4gk1envFu6" },
                new User { ID = 2, StudentID = "19555661", Name = "Eric Howell", Password = "$2a$11$Igdtf.xsMYZHayTNyBjxBei3OE7vKXPsuHcxbnfcHWyMEwpa8GkCa" },
                new User { ID = 3, StudentID = "19555662", Name = "Patricia Lebsack", Password = "$2a$11$5VoUc47EDdqHtTiVha2r6eASOJvEJAanyKt.iXAicbBGOUOsXikOO" },
                new User { ID = 4, StudentID = "19555663", Name = "Kalle Runolfsdottir", Password = "$2a$11$N8oNxha16C13c5GXXLpdM.iphqpjJfN1NXVquhIkZyHdhrip9VExa" },
                new User { ID = 5, StudentID = "19555664", Name = "Linus Reichert", Password = "$2a$11$nVN067GCsOgSUO//7kY64eNk/PAvsGcqLS1YUrNmYdiGuR8hi1N5C" }
            );
            modelBuilder.Entity<MeetingRoom>().HasData(
                new MeetingRoom
                {
                    ID = 1,
                    Name = "101",
                    Capacity = 12,
                    Floor = 0,
                },
                new MeetingRoom
                {
                    ID = 2,
                    Name = "102",
                    Capacity = 12,
                    Floor = 0,
                },
                new MeetingRoom
                {
                    ID = 3,
                    Name = "103",
                    Capacity = 12,
                    Floor = 0,
                },
                new MeetingRoom
                {
                    ID = 4,
                    Name = "104",
                    Capacity = 12,
                    Floor = 0,
                }
            );
            modelBuilder.Entity<StudyRoom>().HasData(
                new StudyRoom
                {
                    ID = 5,
                    Name = "201",
                    Capacity = 12,
                    Floor = 0,
                },
                new StudyRoom
                {
                    ID = 6,
                    Name = "202",
                    Capacity = 12,
                    Floor = 0,
                });
            modelBuilder.Entity<ConferenceRoom>().HasData(
                new ConferenceRoom
                {
                    ID = 7,
                    Name = "301",
                    Capacity = 12,
                    Floor = 0,
                },
                new ConferenceRoom
                {
                    ID = 8,
                    Name = "302",
                    Capacity = 12,
                    Floor = 0,
                },
                new ConferenceRoom
                {
                    ID = 9,
                    Name = "303",
                    Capacity = 12,
                    Floor = 0,
                });
            modelBuilder.Entity<PC>().HasData(
                new PC(1, "1", "Windows 11"),
                new PC(2, "2", "Mac")
            );
            modelBuilder.Entity<Laptop>().HasData(
                new Laptop(3, "3", "Windows 11")
            );
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationID = 1, StartTime = new DateTime(2022, 1, 5, 16, 0, 0), EndTime = new DateTime(2022, 1, 5, 18, 0, 0), UserID = 3 },
                new Reservation { ReservationID = 2, StartTime = new DateTime(2022, 1, 5, 14, 0, 0), EndTime = new DateTime(2022, 1, 5, 16, 0, 0), UserID = 4 }
            );
            modelBuilder.Entity<RoomReservation>().HasData(
                new RoomReservation { ReservationID = 1, RoomID = 3 },
                new RoomReservation { ReservationID = 2, RoomID = 1 }
            );
        }

        private static void ConfigureAuthor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().Property(x => x.Name).HasMaxLength(55);
        }

        private static void ConfigureBookDetails(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDetails>().HasKey(x => x.ID);
            modelBuilder.Entity<BookDetails>().HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorID);
        }

        private static void ConfigureBookCopyLoan(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCopyLoan>().HasKey(x => new { x.BookCopyID, x.LoanID });
            modelBuilder.Entity<BookCopyLoan>().HasOne(pt => pt.BookCopy).WithMany(p => p.BookCopyLoans).HasForeignKey(pt => pt.BookCopyID);
            modelBuilder.Entity<BookCopyLoan>().HasOne(pt => pt.Loan).WithMany(t => t.BookCopyLoans).HasForeignKey(pt => pt.LoanID);
        }

        private static void ConfigureRooms(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("RoomIds").StartsAt(10);
            modelBuilder.Entity<Room>().UseTpcMappingStrategy().Property(e => e.ID).HasDefaultValueSql("NEXT VALUE FOR RoomIds");
        }

        private static void ConfigureFunctionality(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Functionality>().HasNoKey();
            modelBuilder.Entity<ZoomFunctionality>();
            modelBuilder.Entity<PowerFunctionality>();
            modelBuilder.Entity<DisplayFunctionality>();
            modelBuilder.Entity<ComputerFunctionality>();
            modelBuilder.Entity<ConferenceFunctionality>();
            modelBuilder.Entity<WhiteBoardFunctionality>();
            modelBuilder.Entity<ComputerClassFunctionality>();
            modelBuilder.Entity<NoAccessibilityFunctionality>();
        }

        private static void ConfigureReservations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomReservation>().HasKey(x => new { x.RoomID, x.ReservationID });
            modelBuilder.Entity<RoomReservation>().HasOne(pt => pt.Room).WithMany(p => p.RoomReservations).HasForeignKey(pt => pt.RoomID);
            modelBuilder.Entity<RoomReservation>().HasOne(pt => pt.Reservation).WithMany(t => t.RoomReservations).HasForeignKey(pt => pt.ReservationID);
        }

        private static void ConfigureComputer(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("PCIds").StartsAt(4);
            modelBuilder.Entity<Computer>().UseTpcMappingStrategy().Property(e => e.ID).HasDefaultValueSql("NEXT VALUE FOR PCIds");
        }

    }
}
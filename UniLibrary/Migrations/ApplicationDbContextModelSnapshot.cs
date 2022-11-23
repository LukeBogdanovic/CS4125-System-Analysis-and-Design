﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniLibrary.Data;

#nullable disable

namespace UniLibrary.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UniLibrary.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("varchar(55)");

                    b.HasKey("ID");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Laurelli Rolf"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Jordan B Peterson"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Annmarie Palm"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Dale Carnegie"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Bo Gustafsson"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Brian Tracy "
                        },
                        new
                        {
                            ID = 7,
                            Name = "Stephen Denning"
                        },
                        new
                        {
                            ID = 8,
                            Name = "Geoff Watts"
                        },
                        new
                        {
                            ID = 9,
                            Name = "David J Anderson"
                        },
                        new
                        {
                            ID = 10,
                            Name = "Rashina Hoda"
                        },
                        new
                        {
                            ID = 11,
                            Name = "William Shakespeare"
                        },
                        new
                        {
                            ID = 12,
                            Name = "Villiam Skakspjut"
                        },
                        new
                        {
                            ID = 13,
                            Name = "Robert C. Martin"
                        });
                });

            modelBuilder.Entity("UniLibrary.Models.BookCopy", b =>
                {
                    b.Property<int>("BookCopyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DetailsID")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("BookCopyID");

                    b.HasIndex("DetailsID");

                    b.ToTable("BookCopies");

                    b.HasData(
                        new
                        {
                            BookCopyID = 1,
                            DetailsID = 1,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 2,
                            DetailsID = 2,
                            IsAvailable = false
                        },
                        new
                        {
                            BookCopyID = 3,
                            DetailsID = 3,
                            IsAvailable = false
                        },
                        new
                        {
                            BookCopyID = 4,
                            DetailsID = 4,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 5,
                            DetailsID = 5,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 6,
                            DetailsID = 6,
                            IsAvailable = false
                        },
                        new
                        {
                            BookCopyID = 7,
                            DetailsID = 7,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 9,
                            DetailsID = 12,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 10,
                            DetailsID = 12,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 11,
                            DetailsID = 5,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 12,
                            DetailsID = 4,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 13,
                            DetailsID = 8,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 14,
                            DetailsID = 1,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 15,
                            DetailsID = 7,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 16,
                            DetailsID = 11,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 17,
                            DetailsID = 11,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 18,
                            DetailsID = 2,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 19,
                            DetailsID = 9,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 20,
                            DetailsID = 9,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 21,
                            DetailsID = 13,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 22,
                            DetailsID = 5,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 24,
                            DetailsID = 10,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 25,
                            DetailsID = 10,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 26,
                            DetailsID = 13,
                            IsAvailable = true
                        },
                        new
                        {
                            BookCopyID = 27,
                            DetailsID = 13,
                            IsAvailable = true
                        });
                });

            modelBuilder.Entity("UniLibrary.Models.BookCopyLoan", b =>
                {
                    b.Property<int>("BookCopyID")
                        .HasColumnType("int");

                    b.Property<int>("LoanID")
                        .HasColumnType("int");

                    b.HasKey("BookCopyID", "LoanID");

                    b.HasIndex("LoanID");

                    b.ToTable("BookCopyLoans");

                    b.HasData(
                        new
                        {
                            BookCopyID = 4,
                            LoanID = 1
                        },
                        new
                        {
                            BookCopyID = 1,
                            LoanID = 2
                        },
                        new
                        {
                            BookCopyID = 2,
                            LoanID = 3
                        },
                        new
                        {
                            BookCopyID = 3,
                            LoanID = 4
                        },
                        new
                        {
                            BookCopyID = 6,
                            LoanID = 6
                        },
                        new
                        {
                            BookCopyID = 2,
                            LoanID = 5
                        },
                        new
                        {
                            BookCopyID = 3,
                            LoanID = 1
                        },
                        new
                        {
                            BookCopyID = 12,
                            LoanID = 1
                        },
                        new
                        {
                            BookCopyID = 7,
                            LoanID = 2
                        });
                });

            modelBuilder.Entity("UniLibrary.Models.BookDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("BookDetails");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AuthorID = 1,
                            Description = "Arguably Shakespeare's greatest tragedy",
                            ISBN = "1472518381",
                            Title = "Hamlet"
                        },
                        new
                        {
                            ID = 2,
                            AuthorID = 1,
                            Description = "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all.",
                            ISBN = "9780141012292",
                            Title = "King Lear"
                        },
                        new
                        {
                            ID = 3,
                            AuthorID = 2,
                            Description = "An intense drama of love, deception, jealousy and destruction.",
                            ISBN = "1853260185",
                            Title = "Othello"
                        },
                        new
                        {
                            ID = 4,
                            AuthorID = 4,
                            Description = "I Affärsmannaskap har Rolf Laurelli summerat sin långa erfarenhet av konsten att göra affärer. Med boken hoppas han kunna locka fram dina affärsinstinkter.",
                            ISBN = "9789147107483",
                            Title = "Affärsmannaskap för ingenjörer, jurister och alla andra specialister"
                        },
                        new
                        {
                            ID = 5,
                            AuthorID = 5,
                            Description = "12 Rules for Life offers a deeply rewarding antidote to the chaos in our lives: eternal truths applied to our modern problems. ",
                            ISBN = "9780345816023",
                            Title = "12 Rules For Life "
                        },
                        new
                        {
                            ID = 6,
                            AuthorID = 6,
                            Description = "Denna eminenta bok handlar om hur man ska behandla sina affärskontakter för att de ska känna sig trygga med dig som affärspartner. ",
                            ISBN = "9789147122103",
                            Title = "Business behavior"
                        },
                        new
                        {
                            ID = 7,
                            AuthorID = 7,
                            Description = "Dale Carnegie had an understanding of human nature that will never be outdated. Financial success, Carnegie believed, is due 15 percent to professional knowledge and 85 percent to the ability to express ideas, to assume leadership, and to arouse enthusiasm among people.",
                            ISBN = "9781439199190",
                            Title = "How to Win Friends and Influence People"
                        },
                        new
                        {
                            ID = 8,
                            AuthorID = 8,
                            Description = "I Affärsmannaskap har Rolf Laurelli summerat sin långa erfarenhet av konsten att göra affärer. Med boken hoppas han kunna locka fram dina affärsinstinkter.",
                            ISBN = "9789186293321",
                            Title = "Förhandla : från strikta regler till dirty tricks"
                        },
                        new
                        {
                            ID = 9,
                            AuthorID = 9,
                            Description = "Tracy teaches readers how to utilize the six key negotiating styles ",
                            ISBN = "9780814433195",
                            Title = "Negotiation "
                        },
                        new
                        {
                            ID = 13,
                            AuthorID = 13,
                            Description = "The Age of Agile helps readers master the three laws of Agile Management (team, customer, network)",
                            ISBN = "9780814439098",
                            Title = "THE AGE OF AGILE "
                        },
                        new
                        {
                            ID = 10,
                            AuthorID = 10,
                            Description = "The basics of being a ScrumMaster are fairly straightforward: Facilitate the Scrum process and remove impediments. ",
                            ISBN = "9780957587403",
                            Title = "Scrum Mastery "
                        },
                        new
                        {
                            ID = 11,
                            AuthorID = 11,
                            Description = "Optimize the effectiveness of your business, to produce fit-for-purpose products and services that delight your customers, making them loyal to your brand and increasing your share, revenues and margins.",
                            ISBN = "9780984521401",
                            Title = "Kanban "
                        },
                        new
                        {
                            ID = 12,
                            AuthorID = 12,
                            Description = "This  book constitutes the research workshops, doctoral symposium and panel summaries presented at the 20th International Conference on Agile Software Development",
                            ISBN = "9783030301255",
                            Title = " Agile Processes in Software Engineering and Extreme Programming"
                        });
                });

            modelBuilder.Entity("UniLibrary.Models.Loan", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Fee")
                        .HasColumnType("double");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("LoanID");

                    b.HasIndex("UserID");

                    b.ToTable("Loans");

                    b.HasData(
                        new
                        {
                            LoanID = 1,
                            DueDate = new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fee = 0.0,
                            ReturnDate = new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserID = 3
                        },
                        new
                        {
                            LoanID = 2,
                            DueDate = new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fee = 24.0,
                            ReturnDate = new DateTime(2022, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserID = 1
                        },
                        new
                        {
                            LoanID = 3,
                            DueDate = new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fee = 0.0,
                            ReturnDate = new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserID = 2
                        },
                        new
                        {
                            LoanID = 4,
                            DueDate = new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fee = 0.0,
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserID = 2
                        },
                        new
                        {
                            LoanID = 5,
                            DueDate = new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fee = 0.0,
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserID = 4
                        },
                        new
                        {
                            LoanID = 6,
                            DueDate = new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fee = 0.0,
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserID = 5
                        });
                });

            modelBuilder.Entity("UniLibrary.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Daniel Graham",
                            StudentID = "19855666"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Eric Howell",
                            StudentID = "19555661"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Patricia Lebsack",
                            StudentID = "19555662"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Kalle Runolfsdottir",
                            StudentID = "19555663"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Linus Reichert",
                            StudentID = "19555664"
                        });
                });

            modelBuilder.Entity("UniLibrary.Models.BookCopy", b =>
                {
                    b.HasOne("UniLibrary.Models.BookDetails", "Details")
                        .WithMany("Copies")
                        .HasForeignKey("DetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Details");
                });

            modelBuilder.Entity("UniLibrary.Models.BookCopyLoan", b =>
                {
                    b.HasOne("UniLibrary.Models.BookCopy", "BookCopy")
                        .WithMany("BookCopyLoans")
                        .HasForeignKey("BookCopyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniLibrary.Models.Loan", "Loan")
                        .WithMany("BookCopyLoans")
                        .HasForeignKey("LoanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookCopy");

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("UniLibrary.Models.BookDetails", b =>
                {
                    b.HasOne("UniLibrary.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("UniLibrary.Models.Loan", b =>
                {
                    b.HasOne("UniLibrary.Models.User", "User")
                        .WithMany("Loans")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UniLibrary.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("UniLibrary.Models.BookCopy", b =>
                {
                    b.Navigation("BookCopyLoans");
                });

            modelBuilder.Entity("UniLibrary.Models.BookDetails", b =>
                {
                    b.Navigation("Copies");
                });

            modelBuilder.Entity("UniLibrary.Models.Loan", b =>
                {
                    b.Navigation("BookCopyLoans");
                });

            modelBuilder.Entity("UniLibrary.Models.User", b =>
                {
                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}

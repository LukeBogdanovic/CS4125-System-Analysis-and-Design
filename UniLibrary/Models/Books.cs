using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniLibrary.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniLibrary.Models
{
    public class Book
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Required]
        public int Pages { get; set; }
    }

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcBookContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcBookContext>>()))
            {
                if (context.Book.Any())
                {
                    return;
                }
                context.Book.AddRange(
                    new Book
                    {
                        Title = "a",
                        ReleaseDate = DateTime.Parse("1960-4-15"),
                        Genre = "d",
                        Pages = 450,
                        Price = 0.00M
                    }, new Book
                    {
                        Title = "s",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "c",
                        Pages = 750,
                        Price = 0.00M
                    }, new Book
                    {
                        Title = "e",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "f",
                        Pages = 650,
                        Price = 0.00M
                    }, new Book
                    {
                        Title = "g",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "h",
                        Pages = 550,
                        Price = 0.00M
                    }
                );
                context.SaveChanges();
            }
        }
    }

    public class BooksGenreViewModel
    {
        public List<Book> Books { get; set; }
        public SelectList Genres { get; set; }
        public string BookGenre { get; set; }
        public string SearchString { get; set; }
    }

}
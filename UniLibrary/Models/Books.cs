using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniLibrary.Data;
using System;
using System.Linq;

namespace UniLibrary.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
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
                        Price = 0.00M
                    }, new Book
                    {
                        Title = "s",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "c",
                        Price = 0.00M
                    }, new Book
                    {
                        Title = "e",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "f",
                        Price = 0.00M
                    }, new Book
                    {
                        Title = "g",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "h",
                        Price = 0.00M
                    }
                );
                context.SaveChanges();
            }
        }
    }

}
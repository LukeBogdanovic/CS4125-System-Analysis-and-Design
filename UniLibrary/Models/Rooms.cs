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
    public class Room
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? RoomName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? RoomType { get; set; }
        [Required]
        public int Capacity { get; set; }
    }


    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcRoomContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcRoomContext>>()))
            {
                if (context.Room.Any())
                {
                    return;
                }
                context.Room.AddRange(
                    new Room
                    {
                        RoomName = "101",
                        RoomType = "Meeting",
                        Capacity = 10,
                    }, new Room
                    {
                        Title = "102",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "c",
                        Pages = 750,
                        Price = 0.00M
                    }, new Room
                    {
                        Title = "e",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "f",
                        Pages = 650,
                        Price = 0.00M
                    }, new Room
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
}
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


    public static class SeedRoomData
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
                        Capacity = 12,
                    }, new Room
                    {
                        RoomName = "102",
                        RoomType = "Meeting",
                        Capacity = 16,
                    }, new Room
                    {
                        RoomName = "201",
                        RoomType = "Study",
                        Capacity = 6,
                    }, new Room
                    {
                        RoomName = "301",
                        RoomType = "Conference",
                        Capacity = 40,
                    },new Room
                    {
                        RoomName = "302",
                        RoomType = "Conference",
                        Capacity = 50,
                    }
                );
                context.SaveChanges();
            }
        }
    }
        public class RoomsGenreViewModel
    {
        public List<Book> Rooms { get; set; }
        public SelectList RoomType { get; set; }
        public string Capacity { get; set; }
    }

}

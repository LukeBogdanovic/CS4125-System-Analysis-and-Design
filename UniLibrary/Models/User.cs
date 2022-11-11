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
    public class User
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? StuName { get; set; }
        [Display(Name = "Student Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? StuID { get; set; }
        [StringLength(8, MinimumLength =8)]
        [Required]
        public int UserType { get; set; }
    
    }

    // public static class SeedUserData
    // {
    //     public static void Initialize(IServiceProvider serviceProvider)
    //     {
    //         using (var context = new MvcUserContext(
    //             serviceProvider.GetRequiredService<DbContextOptions<MvcUserContext>>()))
    //         {
    //             if (context.User.Any())
    //             {
    //                 return;
    //             }
    //             context.User.AddRange(
    //                 new User
    //                 {
    //                     StuName= "Seanie Lambe SR",
    //                     StuID= "19264268",
    //                     UserType = 1
    //                 }, new User
    //                 {
    //                     StuName= "Seanie Lambe",
    //                     StuID= "19264267",
    //                     UserType = 1
    //                 }

    //             );
    //             context.SaveChanges();
    //         }
    //     }
    // }

}
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
    public class Computer
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? PCNum { get; set; }
        [Required]
        [StringLength(30)]
        public string? OS { get; set; }
        [StringLength(30)]
        [Required]
        public bool Availability { get; set; }   
    }
}



    


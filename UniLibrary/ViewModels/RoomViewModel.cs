using UniLibrary.Models;
using UniLibrary.Factories;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UniLibrary.ViewModels
{
    public class RoomViewModel
    {
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public string? Room { get; set; }
    }
}
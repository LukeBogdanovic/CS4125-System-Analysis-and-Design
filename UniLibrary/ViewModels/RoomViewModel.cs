using UniLibrary.Models;
using UniLibrary.Factories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniLibrary.ViewModels
{
    public class RoomViewModel
    {
        public string? Name { get; set; }
        public int Capacity {get; set; }
        public int Floor {get; set;}
        public IEnumerable<SelectListItem>? Room { get; set; }
    }
}
using UniLibrary.Models;
using UniLibrary.Factories;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UniLibrary.ViewModels
{
    public class RoomViewModel
    {
        public Room? Room { get; set; }
        [ValidateNever]
        [Display(Name = "Name")]
        public IEnumerable<SelectListItem>? Authors { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? BookCopies { get; set; }
        [ValidateNever]
        public int Copies { get; set; } = 0;
    }
}
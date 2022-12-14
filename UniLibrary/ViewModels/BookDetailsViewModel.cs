using UniLibrary.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniLibrary.ViewModels
{
    public class BookDetailsViewModel
    {
        public BookDetails? BookDetails { get; set; }
        [ValidateNever]
        [Display(Name = "Author")]
        public IEnumerable<SelectListItem>? Authors { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? BookCopies { get; set; }
        [ValidateNever]
        public int Copies { get; set; } = 0;
    }
}
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UniLibrary.Models
{
    public class BookCopy
    {
        [Display(Name = "Book Copy")]
        public int BookCopyID { get; set; }
        public int DetailsID { get; set; }
        [ValidateNever]
        public BookDetails? Details { get; set; }
        [ValidateNever]
        public List<BookCopyLoan>? BookCopyLoans { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
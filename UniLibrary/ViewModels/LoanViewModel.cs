using UniLibrary.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniLibrary.ViewModels
{
    public class LoanViewModel
    {

        [ValidateNever]
        public Loan? Loan { get; set; }

        [ValidateNever]
        public IReadOnlyList<Loan>? Loans { get; set; }

        [ValidateNever]
        public IReadOnlyList<BookCopy>? BookCopies { get; set; }

        [ValidateNever]
        public IReadOnlyList<BookCopyLoan>? BookCopyLoans { get; set; }

        [ValidateNever]
        public BookCopy? BookCopy { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? Copies { get; set; }

        [ValidateNever]
        public User? User { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? Users { get; set; }
    }
}
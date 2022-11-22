namespace UniLibrary.Models
{
    public class BookCopyLoan
    {
        public int BookCopyID { get; set; }
        public BookCopy? BookCopy { get; set; }
        public int LoanID { get; set; }
        public Loan? Loan { get; set; }
    }
}
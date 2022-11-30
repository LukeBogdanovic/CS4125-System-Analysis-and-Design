using UniLibrary.Models.Utilities;
using UniLibrary.Decorator;

namespace UniLibrary.Models
{

    public class Loan
    {

        public int LoanID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
        public double Fee { get; set; }
        public List<BookCopyLoan>? BookCopyLoans { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }

        public Loan()
        {
            StartDate = DateTime.Now;
            DueDate = DateTime.Now.AddDays(FeeSettings.Days);
        }
        public double setFee(int copies)
        {
            return Fee = (DateTime.Now > DueDate) ? (DateTime.Now - DueDate).Days * (FeeSettings.FeePerDayPerBook) * copies : 0;
        }

        public void setReturnDate()
        {
            ReturnDate = DateTime.Now;
        }

    }

}
using UniLibrary.Models.Utilities;
using UniLibrary.Decorator;
using UniLibrary.Models.Enums;

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
        public double setFee(int copies, UserType type = UserType.UnderGraduate)
        {
            BaseFee baseFee = new Fee();
            baseFee.CreateFee();
            switch (type)
            {
                case UserType.Admin:
                    FeeDecorator AdminDecorator = new AdminDecorator();
                    AdminDecorator.AttachTo(baseFee);
                    AdminDecorator.CreateFee();
                    return Fee = (DateTime.Now > DueDate) ? (DateTime.Now - DueDate).Days * (AdminDecorator.Fee) * copies : 0;
                case UserType.PostGraduate:
                    FeeDecorator PostGradDecorator = new PostGradDecorator();
                    PostGradDecorator.AttachTo(baseFee);
                    PostGradDecorator.CreateFee();
                    return Fee = (DateTime.Now > DueDate) ? (DateTime.Now - DueDate).Days * (PostGradDecorator.Fee) * copies : 0;
                default:
                    FeeDecorator UnderGradDecorator = new UnderGradDecorator();
                    UnderGradDecorator.AttachTo(baseFee);
                    UnderGradDecorator.CreateFee();
                    return Fee = (DateTime.Now > DueDate) ? (DateTime.Now - DueDate).Days * (UnderGradDecorator.Fee) * copies : 0;
            }
        }

        public void setReturnDate()
        {
            ReturnDate = DateTime.Now;
        }

    }

}
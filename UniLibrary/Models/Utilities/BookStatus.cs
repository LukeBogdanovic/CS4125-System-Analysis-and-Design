using UniLibrary.Interfaces;

namespace UniLibrary.Models.Utilities
{

    public static class BookStatus
    {
        public const int Max = 9;
    }

    public class BookStatusAdmin : IStrategy
    {

        public int setBookStatus(int bookStatus)
        {
            return bookStatus * 3;
        }

    }

    public class BookStatusUnderGrad : IStrategy
    {

        public int setBookStatus(int bookStatus)
        {
            return bookStatus;
        }

    }

    public class BookStatusPostGrad : IStrategy
    {

        public int setBookStatus(int bookStatus)
        {
            return bookStatus * 2;
        }

    }

}
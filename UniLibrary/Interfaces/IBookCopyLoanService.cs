using UniLibrary.Models;

namespace UniLibrary.Interfaces
{
    public interface IBookCopyLoanService : IAsyncGenericRepository<BookCopyLoan>
    {
        Task<BookCopyLoan> GetBookCopyLoanOrDefaultAsync();
        Task<IReadOnlyList<BookCopyLoan>> GetAllBookCopyLoansAsync();
        void RemoveRange(IEnumerable<BookCopyLoan> entities);
    }
}
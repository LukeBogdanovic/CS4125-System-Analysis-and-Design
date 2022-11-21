using UniLibrary.Models;

namespace UniLibrary.Interfaces
{
    public interface IBookCopyService : IAsyncGenericRepository<BookCopy>
    {
        Task<IReadOnlyList<BookCopy>> GetAllBookCopiesAsync();
        Task<BookCopy> GetBookCopyOrDefaultAsync();
        void RemoveRange(IEnumerable<BookCopy> entities);
    }
}
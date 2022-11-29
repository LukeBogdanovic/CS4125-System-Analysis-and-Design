using UniLibrary.Models;
using System.Linq.Expressions;

namespace UniLibrary.Interfaces
{
    public interface IBookService : IAsyncGenericRepository<BookDetails>
    {
        Task<IReadOnlyList<BookDetails>> GetAllBookDetailsAsync(Expression<Func<BookDetails, bool>>? filter = null, Func<IQueryable<BookDetails>, IOrderedQueryable<BookDetails>>? orderBy = null, params Expression<Func<BookDetails, object>>[] includeProperties);
        BookDetails GetBookOrDefault(Expression<Func<BookDetails, bool>> filter, string? includeProperties = null, bool tracked = true);
    }
}
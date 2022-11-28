using UniLibrary.Models;
using System.Linq.Expressions;

namespace UniLibrary.Interfaces
{
    public interface ILoanService : IAsyncGenericRepository<Loan>
    {
        Task<IReadOnlyList<Loan>> GetAllLoansAsync(Expression<Func<Loan, bool>>? filter = null, Func<IQueryable<Loan>, IOrderedQueryable<Loan>>? orderBy = null, params Expression<Func<Loan, object>>[] includeProperties);
        Loan GetLoanOrDefault(Expression<Func<Loan, bool>> filter, string? includeProperties = null, bool tracked = true);
    }
}
using UniLibrary.Models;
using System.Linq.Expressions;

namespace UniLibrary.Interfaces
{

    public interface IComputerService : IAsyncGenericRepository<Computer>
    {
        Task<IReadOnlyList<Computer>> GetAllComputersAsync(Expression<Func<Computer, bool>>? filter = null, Func<IQueryable<Computer>, IOrderedQueryable<Computer>>? orderBy = null, params Expression<Func<Computer, object>>[] includeProperties);
        Task<Computer> GetComputerOrDefaultAsync(Expression<Func<Computer, bool>> filter, string? includeProperties = null, bool tracked = true);
    }

}
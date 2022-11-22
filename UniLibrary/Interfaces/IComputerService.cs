using UniLibrary.Models;
using System.Linq.Expressions;

namespace UniLibrary.Interfaces
{

    public interface IComputerService
    {
        Task<IReadOnlyList<Computer>> GetAllBookDetailsAsync(Expression<Func<Computer, bool>>? filter = null, Func<IQueryable<Computer>, IOrderedQueryable<Computer>>? orderBy = null, params Expression<Func<Computer, object>>[] includeProperties);
        Task<Computer> GetBookOrDefaultAsync(Expression<Func<Computer, bool>> filter, string? includeProperties = null, bool tracked = true);
    }

}
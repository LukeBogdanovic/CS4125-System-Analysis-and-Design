using UniLibrary.Models;
using System.Linq.Expressions;

namespace UniLibrary.Interfaces
{
    public interface IUserService : IAsyncGenericRepository<User>
    {
        Task<IReadOnlyList<User>> GetAllUsersAsync(Expression<Func<User, bool>>? filter = null, Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null, params Expression<Func<User, object>>[] includeProperties);
        Task<User> GetUserByIdAsync(int id, bool includeProperties);
    }
}
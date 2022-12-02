using UniLibrary.Factories;
using System.Linq.Expressions;

namespace UniLibrary.Interfaces
{

    public interface IRoomService : IAsyncGenericRepository<Room>
    {
        Task<IReadOnlyList<Room>> GetAllRoomsAsync(Expression<Func<Room, bool>>? filter = null, Func<IQueryable<Room>, IOrderedQueryable<Room>>? orderBy = null, params Expression<Func<Room, object>>[] includeProperties);
        Room GetRoomOrDefaultAsync(Expression<Func<Room, bool>> filter, string? includeProperties = null, bool tracked = true);
    }
}
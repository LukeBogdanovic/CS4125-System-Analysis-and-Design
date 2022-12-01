using UniLibrary.Models;
using System.Linq.Expressions;

namespace UniLibrary.Interfaces
{
    public interface IRoomReservationService : IAsyncGenericRepository<RoomReservation>
    {
        RoomReservation GetRoomReservationOrDefault(Expression<Func<RoomReservation, bool>> filter, string? includeProperties = null, bool tracked = true);
        Task<IReadOnlyList<RoomReservation>> GetAllRoomReservationsAsync(Expression<Func<RoomReservation, bool>>? filter = null, Func<IQueryable<RoomReservation>, IOrderedQueryable<RoomReservation>>? orderBy = null, params Expression<Func<RoomReservation, object>>[] includeProperties);
        void RemoveRange(IEnumerable<RoomReservation> entities);
    }
}

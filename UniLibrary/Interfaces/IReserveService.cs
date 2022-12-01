using System.Linq.Expressions;
using UniLibrary.Models;

namespace UniLibrary.Interfaces
{

    public interface IReserveService : IAsyncGenericRepository<Reservation>
    {
        Task<IReadOnlyList<Reservation>> GetAllReservationsAsync(Expression<Func<Reservation, bool>>? filter = null, Func<IQueryable<Reservation>, IOrderedQueryable<Reservation>>? orderBy = null, params Expression<Func<Reservation, object>>[] includeProperties);
        Reservation GetReservationOrDefault(Expression<Func<Reservation, bool>> filter, string? includeProperties = null, bool tracked = true);
    }

}
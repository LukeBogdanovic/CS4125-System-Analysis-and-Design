using UniLibrary.Interfaces;
using UniLibrary.Models;
using UniLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace UniLibrary.Services
{

    public class RoomReservationService : BaseService<RoomReservation>, IRoomReservationService
    {

        public RoomReservationService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<RoomReservation>> GetAllRoomReservationsAsync(Expression<Func<RoomReservation, bool>>? filter = null, Func<IQueryable<RoomReservation>, IOrderedQueryable<RoomReservation>>? orderBy = null, params Expression<Func<RoomReservation, object>>[] includeProperties)
        {
            IQueryable<RoomReservation> query = _table;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties)
                {
                    query = query.Include(includeProp);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.ToListAsync();
        }

        public RoomReservation GetRoomReservationOrDefault(Expression<Func<RoomReservation, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            if (tracked)
            {
                IQueryable<RoomReservation> query = _table;
                query = query.Where(filter);
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault()!;
            }
            else
            {
                IQueryable<RoomReservation> query = _table.AsNoTracking();
                query = query.Where(filter);
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault()!;
            }
        }

        public void RemoveRange(IEnumerable<RoomReservation> entities)
        {
            _table.RemoveRange(entities);
        }

    }

}
using UniLibrary.Interfaces;
using UniLibrary.Factories;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UniLibrary.Data;

namespace UniLibrary.Services
{
    public class RoomService : BaseService<Room>, IRoomService
    {

        public RoomService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Room>> GetAllRoomsAsync(Expression<Func<Room, bool>>? filter = null, Func<IQueryable<Room>, IOrderedQueryable<Room>>? orderBy = null, params Expression<Func<Room, object>>[] includeProperties)
        {
            IQueryable<Room> query = _table;
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

        public Room GetRoomOrDefaultAsync(Expression<Func<Room, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            if (tracked)
            {
                IQueryable<Room> query = _table;
                query = query.Where(filter);
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault();
            }
            else
            {
                IQueryable<Room> query = _table.AsNoTracking();
                query = query.Where(filter);
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault();
            }
        }

    }

}
using UniLibrary.Models;
using UniLibrary.Interfaces;
using UniLibrary.Data;
using System.Data.Common;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace UniLibrary.Services
{

    public class ReservationService : BaseService<Reservation>, IReserveService
    {

        public ReservationService(ApplicationDbContext context) : base(context)
        {
        }

        public Reservation GetReservationOrDefault(Expression<Func<Reservation, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            if (tracked)
            {
                IQueryable<Reservation> query = _table;
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
                IQueryable<Reservation> query = _table.AsNoTracking();
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

        public async Task<IReadOnlyList<Reservation>> GetAllReservationsAsync(Expression<Func<Reservation, bool>>? filter = null, Func<IQueryable<Reservation>, IOrderedQueryable<Reservation>>? orderBy = null, params Expression<Func<Reservation, object>>[] includeProperties)
        {
            IQueryable<Reservation> query = _table;
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

    }

}
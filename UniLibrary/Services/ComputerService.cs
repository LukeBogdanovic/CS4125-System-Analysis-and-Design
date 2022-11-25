using UniLibrary.Interfaces;
using UniLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UniLibrary.Models;

namespace UniLibrary.Services
{
#nullable disable
    public class ComputerService : BaseService<Computer>, IComputerService
    {

        public ComputerService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Computer>> GetAllComputersAsync(Expression<Func<Computer, bool>>? filter = null, Func<IQueryable<Computer>, IOrderedQueryable<Computer>> orderBy = null, params Expression<Func<Computer, object>>[] includeProperties)
        {
            IQueryable<Computer> query = _table;
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

        public async Task<Computer> GetComputerOrDefaultAsync(Expression<Func<Computer, bool>> filter, string includeProperties = null, bool tracked = true)
        {
            if (tracked)
            {
                IQueryable<Computer> query = _table;
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
                IQueryable<Computer> query = _table.AsNoTracking();
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
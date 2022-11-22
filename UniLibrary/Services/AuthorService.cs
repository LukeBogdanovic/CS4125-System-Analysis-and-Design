using UniLibrary.Interfaces;
using UniLibrary.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UniLibrary.Data;

namespace UniLibrary.Services
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {

        public AuthorService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Author>> GetAllAuthorsAsync(Expression<Func<Author, bool>>? filter = null, Func<IQueryable<Author>, IOrderedQueryable<Author>>? orderBy = null, params Expression<Func<Author, object>>[] includeProperties)
        {
            IQueryable<Author> query = _table;
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
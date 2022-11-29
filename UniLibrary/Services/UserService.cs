using UniLibrary.Interfaces;
using UniLibrary.Models;
using UniLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace UniLibrary.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<User>> GetAllUsersAsync(Expression<Func<User, bool>>? filter, Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy, params Expression<Func<User, object>>[] includeProperties)
        {
            IQueryable<User> query = _table;
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

        public async Task<User> GetUserByIdAsync(int id, bool includeProperties)
        {
            User? User = new();
            User = includeProperties ? await _table.Include(m => m.Loans)!.ThenInclude(l => l.BookCopyLoans)!.ThenInclude(b => b.BookCopy).ThenInclude(b => b!.Details).FirstOrDefaultAsync(x => x.ID == id) : await GetByIDAsync(id);
            return User!;
        }
    }
}
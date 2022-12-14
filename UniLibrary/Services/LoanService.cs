using UniLibrary.Interfaces;
using UniLibrary.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UniLibrary.Data;

namespace UniLibrary.Services
{
#nullable disable

    public class LoanService : BaseService<Loan>, ILoanService
    {
        public LoanService(ApplicationDbContext context) : base(context)
        {
        }

        public Loan GetLoanOrDefault(Expression<Func<Loan, bool>> filter, string includeProperties = null, bool tracked = true)
        {
            if (tracked)
            {
                IQueryable<Loan> query = _table;
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
                IQueryable<Loan> query = _table.AsNoTracking();
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

        public async Task<IReadOnlyList<Loan>> GetAllLoansAsync(Expression<Func<Loan, bool>> filter = null, Func<IQueryable<Loan>, IOrderedQueryable<Loan>> orderBy = null, params Expression<Func<Loan, object>>[] includeProperties)
        {
            IQueryable<Loan> query = _table;
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
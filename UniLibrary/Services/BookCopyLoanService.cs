using UniLibrary.Interfaces;
using UniLibrary.Models;
using UniLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace UniLibrary.Services
{
    public class BookCopyLoanService : BaseService<BookCopyLoan>, IBookCopyLoanService
    {
        public BookCopyLoanService(ApplicationDbContext context) : base(context)
        {
        }

        /*
        Builds an SQL query to get all book copy loans from the database.
        Uses LINQ to translate from C# code to SQL query.
        */
        public async Task<IReadOnlyList<BookCopyLoan>> GetAllBookCopyLoansAsync(Expression<Func<BookCopyLoan, bool>>? filter = null, Func<IQueryable<BookCopyLoan>, IOrderedQueryable<BookCopyLoan>>? orderBy = null, params Expression<Func<BookCopyLoan, object>>[] includeProperties)
        {
            // Querying bookCopyLoans table in the database
            IQueryable<BookCopyLoan> query = _table;
            // Getting all values from the database that are based on the predicate passed from the function call
            if (filter != null)
            {
                query = query.Where(filter);
            }
            // Getting all entities specified in the function call using the SQL query
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties)
                {
                    query = query.Include(includeProp);
                }

            }
            // Ordering the returned values of the query
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            // Getting all results from the query in a List
            return await query.ToListAsync();
        }

        public BookCopyLoan GetBookCopyLoanOrDefault(Expression<Func<BookCopyLoan, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            if (tracked)
            {
                IQueryable<BookCopyLoan> query = _table;
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
                IQueryable<BookCopyLoan> query = _table.AsNoTracking();
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

        public void RemoveRange(IEnumerable<BookCopyLoan> entities)
        {
            _table.RemoveRange(entities);
        }

    }
}
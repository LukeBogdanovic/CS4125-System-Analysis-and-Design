using Microsoft.EntityFrameworkCore;
using UniLibrary.Interfaces;
using UniLibrary.Data;

namespace UniLibrary.Services
{
#pragma warning disable
    public abstract class BaseService<T> : IAsyncGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal readonly DbSet<T> _table;

        public BaseService(ApplicationDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        // Converts all rows of a table in database to a List
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }
        // Converts the row found by id to A List
        public async Task<T> GetByIDAsync(int id)
        {
            return await _table.FindAsync(id);
        }
        // Adds the specified row to the database table corresponding to the class
        public async Task<T> AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        // Updates the specified row of the database table corresponding to the class
        public async Task<T> UpdateAsync(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
        // Deletes the specified row of the database table corresponding to the class
        public async Task<T> DeleteAsync(int id)
        {
            var entity = await GetByIDAsync(id);
            _table.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
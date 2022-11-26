namespace UniLibrary.Interfaces
{
    public interface IAsyncGenericRepository<T> where T : class
    {
        public Task<T> GetByIDAsync(int id);
        public Task<IReadOnlyList<T>> GetAllAsync();
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public abstract Task<T> DeleteAsync(int id);
    }
}
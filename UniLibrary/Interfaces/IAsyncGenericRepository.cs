namespace UniLibrary.Interfaces
{
    public interface IAsyncGenericRepository<T> where T : class
    {
        Task<T> GetByIDAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
    }
}
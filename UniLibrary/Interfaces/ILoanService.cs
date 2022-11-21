using UniLibrary.Models;

namespace UniLibrary.Interfaces
{
    public interface ILoanService : IAsyncGenericRepository<Loan>
    {
        Task<IReadOnlyList<Loan>> GetAllLoanAsync();
        Task<Loan> GetLoanOrDefaultAsync();
    }
}
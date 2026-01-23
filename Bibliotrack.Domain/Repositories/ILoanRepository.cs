using Bibliotrack.Domain.Entities;

namespace Bibliotrack.Domain.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAll(string? search);
        Task<Loan?> GetById(int id);
        Task<bool> ExistsActiveLoanForBook(int bookId);
        Task<int> Add(Loan loan);
        Task Update(Loan loan);
        Task Delete(int id);
        Task ReturnBook(int id);
    }
}

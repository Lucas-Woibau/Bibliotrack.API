using Bibliotrack.Domain.Common.Pagination;
using Bibliotrack.Domain.Entities;

namespace Bibliotrack.Domain.Repositories
{
    public interface ILoanRepository
    {
        Task<PagedResult<Loan>> GetAll(string? search, int page, int size);
        Task<Loan?> GetById(int id);
        Task<bool> ExistsActiveLoanForBook(int bookId);
        Task<int> Add(Loan loan);
        Task Update(Loan loan);
        Task Delete(int id);
        Task ReturnBook(int id);
    }
}

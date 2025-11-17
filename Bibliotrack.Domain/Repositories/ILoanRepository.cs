using Bibliotrack.Domain.Entities;

namespace Bibliotrack.Domain.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAll();
        Task<Loan?> GetById(int id);
        Task<int> Add(Loan loan);
        Task Update(Loan loan);
        Task Delete(int id);
        Task ReturnBook(int id);
    }
}

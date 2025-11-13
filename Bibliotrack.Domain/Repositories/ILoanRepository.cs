using Bibliotrack.Domain.Entities;

namespace Bibliotrack.Domain.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAll();
        Task<Loan?> GetById(int id);
        Task Update(Loan book);
        Task Delete(Loan book);
    }
}

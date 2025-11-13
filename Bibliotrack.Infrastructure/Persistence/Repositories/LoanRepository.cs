using Bibliotrack.Domain.Entities;
using Bibliotrack.Domain.Repositories;

namespace Bibliotrack.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BibliotrackDbContext _context;

        public LoanRepository(BibliotrackDbContext context)
        {
            _context = context;
        }

        public Task<List<Loan>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Loan?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Loan book)
        {
            throw new NotImplementedException();
        }

        public Task Update(Loan book)
        {
            throw new NotImplementedException();
        }
    }
}

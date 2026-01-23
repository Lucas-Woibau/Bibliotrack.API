using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Entities;
using Bibliotrack.Domain.Enums;
using Bibliotrack.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bibliotrack.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BibliotrackDbContext _context;

        public LoanRepository(BibliotrackDbContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetAll(string? search)
        {
            var loans = await _context.Loans
                .Include(l => l.Book)
                .Where(b => !b.IsDeleted)
                .Where(b => string.IsNullOrEmpty(search) ||
                 b.Book.Title.Contains(search) || b.PersonName.Contains(search))
                .ToListAsync();

            return loans;
        }

        public async Task<Loan?> GetById(int id)
        {
            var loan = await _context.Loans
                .Include(l => l.Book)
                .Where(b => !b.IsDeleted)
                .SingleOrDefaultAsync(b => b.Id == id);

            return loan;
        }
        public async Task<int> Add(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();

            return loan.Id;
        }
        public async Task Update(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var loan = await GetById(id);

            if (loan is null)
                return;

            loan.SetAsDeleted();
            _context.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task ReturnBook(int id)
        {
            var loan = await GetById(id);
            if (loan is null) 
                return;

            _context.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsActiveLoanForBook(int bookId)
        {
            return await _context.Loans
                .AnyAsync(l => l.IdBook == bookId &&
                               l.Status == LoanStatus.Emprestado);
        }
    }
}

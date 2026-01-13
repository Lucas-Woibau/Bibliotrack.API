using Bibliotrack.Domain.Entities;
using Bibliotrack.Domain.Enums;
using Bibliotrack.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bibliotrack.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BibliotrackDbContext _context;

        public BookRepository(BibliotrackDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAll(string? search)
        {
            var books = await _context.Books
                .AsNoTracking()
                .Where(b => !b.IsDeleted)
                .Where(b => string.IsNullOrEmpty(search) ||
                 b.Title.Contains(search))
                .ToListAsync();

            return books;
        }

        public async Task<Book?> GetById(int id)
        {
            var book = await _context.Books
                .Where(b => !b.IsDeleted)
                .SingleOrDefaultAsync(b => b.Id == id);

            return book;
        }

        public async Task<int> Add(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task Update(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var book = await GetById(id);

            if (book is null)
                return;

            book.SetAsDeleted();
            _context.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetBooksToLoan(string? search)
        {
            var books = await _context.Books
                .Where(b => !b.IsDeleted &&
                 b.Status == BookStatus.Disponível)
                .Where(b => string.IsNullOrEmpty(search) ||
                 b.Title.Contains(search))
                .ToListAsync();

            return books;
        }
    }
}

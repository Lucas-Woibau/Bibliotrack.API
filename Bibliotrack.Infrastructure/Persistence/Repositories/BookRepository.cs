using Bibliotrack.Domain.Entities;
using Bibliotrack.Domain.Repositories;

namespace Bibliotrack.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BibliotrackDbContext _context;

        public BookRepository(BibliotrackDbContext context)
        {
            _context = context;
        }

        public Task<List<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Add(Book book)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Book book)
        {
            throw new NotImplementedException();
        }

        public Task Update(Book book)
        {
            throw new NotImplementedException();
        }   
    }
}

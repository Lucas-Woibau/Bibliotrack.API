using Bibliotrack.Domain.Common.Pagination;
using Bibliotrack.Domain.Entities;

namespace Bibliotrack.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<PagedResult<Book>> GetAll(string? search, int page, int size);
        Task<Book?> GetById(int id);
        Task<List<Book>> GetBooksToLoan(string? search);
        Task<int> Add(Book book);
        Task Update(Book book);
        Task Delete(int id);
    }
}

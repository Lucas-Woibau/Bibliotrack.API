using Bibliotrack.Domain.Entities;

namespace Bibliotrack.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book?> GetById(int id);
        Task<int> Add(Book book);
        Task Update(Book book);
        Task Delete(Book book);
    }
}

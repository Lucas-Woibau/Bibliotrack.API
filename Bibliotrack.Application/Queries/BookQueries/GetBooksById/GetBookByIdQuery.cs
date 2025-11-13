using Bibliotrack.Application.Models;
using MediatR;

namespace Bibliotrack.Application.Queries.Book.GetBooksById
{
    public class GetBookByIdQuery : IRequest<ResultViewModel<BookViewModel>>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

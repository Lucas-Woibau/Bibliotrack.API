using Bibliotrack.Application.Models;
using MediatR;

namespace Bibliotrack.Application.Queries.Book.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<ResultViewModel<List<BookItemViewModel>>>
    {
        public string Search { get; set; } = string.Empty;

        public GetAllBooksQuery(string search)
        {
            Search = search;
        }
    }
}

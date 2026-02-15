using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Common.Pagination;
using MediatR;

namespace Bibliotrack.Application.Queries.Book.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<ResultViewModel<PagedResult<BookItemViewModel>>>
    {
        public string Search { get; }
        public int Page { get; }
        public int Size { get; }

        public GetAllBooksQuery(string search, int page, int size)
        {
            Search = search;
            Page = page < 1 ? 1 : page;
            Size = size < 1 ? 30 : size;
        }
    }
}

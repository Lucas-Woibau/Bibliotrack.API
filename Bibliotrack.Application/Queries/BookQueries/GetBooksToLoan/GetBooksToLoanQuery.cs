using Bibliotrack.Application.Models;
using MediatR;

namespace Bibliotrack.Application.Queries.BookQueries.GetBooksToLoan
{
    public class GetBooksToLoanQuery : IRequest<ResultViewModel<List<BookItemViewModel>>>
    {
        public string? Search { get; set; }

        public GetBooksToLoanQuery(string? search)
        {
            Search = search;
        }
    }
}

using Bibliotrack.Application.Models;
using MediatR;

namespace Bibliotrack.Application.Queries.LoanQueries.GetAllLoans
{
    public class GetAllLoansQuery : IRequest<ResultViewModel<List<LoanItemViewModel>>>
    {
        public string Search { get; }
        public int Page { get; }
        public int Size { get; }

        public GetAllLoansQuery(string search, int page, int size)
        {
            Search = search;
            Page = page < 1 ? 1 : page;
            Size = size < 1 ? 30 : size;
        }
    }
}

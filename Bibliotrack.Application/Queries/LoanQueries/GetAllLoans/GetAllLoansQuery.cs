using Bibliotrack.Application.Models;
using MediatR;

namespace Bibliotrack.Application.Queries.LoanQueries.GetAllLoans
{
    public class GetAllLoansQuery : IRequest<ResultViewModel<List<LoanItemViewModel>>>
    {
        public string? Search { get; set; }

        public GetAllLoansQuery(string? search)
        {
            Search = search;
        }
    }
}

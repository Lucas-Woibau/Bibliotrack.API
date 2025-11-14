using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Entities;
using MediatR;

namespace Bibliotrack.Application.Queries.LoanQueries.GetAllLoans
{
    public class GetAllLoansQuery : IRequest<ResultViewModel<List<LoanItemViewModel>>>
    {
    }
}

using Bibliotrack.Application.Models;
using MediatR;

namespace Bibliotrack.Application.Queries.LoanQueries.GetLoanById
{
    public class GetLoanByIdQuery : IRequest<ResultViewModel<LoanViewModel>>
    {
        public GetLoanByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

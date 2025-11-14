using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Queries.LoanQueries.GetAllLoans
{
    public class GetAllLoansHandler : IRequestHandler<GetAllLoansQuery, ResultViewModel<List<LoanItemViewModel>>>
    {
        private readonly ILoanRepository _loanRepository;

        public GetAllLoansHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel<List<LoanItemViewModel>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetAll();

            var model = loans.Select(LoanItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<LoanItemViewModel>>.Success(model);
        }
    }
}

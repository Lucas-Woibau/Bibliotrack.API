using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Queries.LoanQueries.GetLoanById
{
    public class GetLoanByIdHandler : IRequestHandler<GetLoanByIdQuery, ResultViewModel<LoanViewModel>>
    {
        private readonly ILoanRepository _loanRepository;

        public GetLoanByIdHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public async Task<ResultViewModel<LoanViewModel>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetById(request.Id);

            if (loan == null)
                return ResultViewModel<LoanViewModel>.Error("Loan not found.");

            var model = LoanViewModel.FromEntity(loan);

            return ResultViewModel<LoanViewModel>.Success(model);
        }
    }
}

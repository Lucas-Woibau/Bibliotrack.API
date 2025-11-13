using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Queries.Loan
{
    public class GetLoanByIdQuery : IRequest<ResultViewModel<LoanViewModel>>
    {
        public GetLoanByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class GetLoanByIdHanlder : IRequestHandler<GetLoanByIdQuery, ResultViewModel<LoanViewModel>>
    {
        private readonly ILoanRepository _loanRepository;

        public GetLoanByIdHanlder(ILoanRepository loanRepository)
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

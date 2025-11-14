using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.AddLoan
{
    public class AddLoanHandler : IRequestHandler<AddLoanCommand, ResultViewModel<int>>
    {
        private readonly ILoanRepository _loanRepository;

        public AddLoanHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel<int>> Handle(AddLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = request.ToEntity();

            var id = await _loanRepository.Add(loan);

            return ResultViewModel<int>.Success(id);
        }
    }
}

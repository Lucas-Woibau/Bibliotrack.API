using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.DeleteLoan
{
    public class DeleteLoanHandler : IRequestHandler<DeleteLoanCommand, ResultViewModel>
    {
        private readonly ILoanRepository _loanRepository;

        public DeleteLoanHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetById(request.Id);

            if (loan == null)
                return ResultViewModel.Error("Loan not found.");

            await _loanRepository.Delete(loan.Id);

            return ResultViewModel.Success();
        }
    }
}

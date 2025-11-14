using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.UpdateLoan
{
    public class UpdateLoanHandler : IRequestHandler<UpdateLoanCommand, ResultViewModel>
    {
        private readonly ILoanRepository _loanRepository;

        public UpdateLoanHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetById(request.IdLoan);

            if (loan == null)
                return ResultViewModel.Error("Loan not found.");

            loan.Update(request.Book,request.PersonName,request.LoanDate,request.ReturnDate);
            await _loanRepository.Update(loan);

            return ResultViewModel.Success();
        }
    }
}

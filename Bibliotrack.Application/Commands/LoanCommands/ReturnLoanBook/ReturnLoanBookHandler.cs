using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.ReturnLoanBook
{
    public class ReturnLoanBookHandler : IRequestHandler<ReturnLoanBookCommand, ResultViewModel>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;

        public ReturnLoanBookHandler(ILoanRepository loanRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
        }
        public async Task<ResultViewModel> Handle(ReturnLoanBookCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetById(request.Id);

            if (loan == null)
                return ResultViewModel.Error("Loan not found.");

            var returned = loan.ReturnLoan();

            if (!returned)
                return ResultViewModel.Error("Loan already returned.");

            await _loanRepository.Update(loan);

            return ResultViewModel.Success();
        }
    }
}

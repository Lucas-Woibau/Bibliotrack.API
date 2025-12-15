using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.UpdateLoan
{
    public class UpdateLoanHandler : IRequestHandler<UpdateLoanCommand, ResultViewModel>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;

        public UpdateLoanHandler(ILoanRepository loanRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetById(request.IdLoan);

            if (loan == null)
                return ResultViewModel.Error("Loan not found.");

            var book = await _bookRepository.GetById(request.IdBook);
            if (book == null)
                return ResultViewModel.Error("Book not found.");

            loan.Update(request.IdBook, book, request.PersonName, request.LoanDate, request.ExpectedReturnDate, request.Status);
            await _loanRepository.Update(loan);

            return ResultViewModel.Success();
        }
    }
}

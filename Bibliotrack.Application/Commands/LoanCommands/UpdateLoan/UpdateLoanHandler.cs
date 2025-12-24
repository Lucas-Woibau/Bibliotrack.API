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

            var newBook = await _bookRepository.GetById(request.IdBook);
            if (newBook == null)
                return ResultViewModel.Error("Book not found.");

            if(loan.IdBook != request.IdBook)
            {
                loan.Book.IncreaseQuantity();

                if (newBook.Quantity <= 0)
                    return ResultViewModel.Error("Book out of stock");

                newBook.DecreaseQuantity();
                await _bookRepository.Update(newBook);
            }

            loan.Update(request.IdBook, newBook, request.PersonName, request.LoanDate, request.ExpectedReturnBook, request.ReturnDate);
            await _loanRepository.Update(loan);

            return ResultViewModel.Success();
        }
    }
}

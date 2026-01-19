using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.DeleteLoan
{
    public class DeleteLoanHandler : IRequestHandler<DeleteLoanCommand, ResultViewModel>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;

        public DeleteLoanHandler(ILoanRepository loanRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetById(request.Id);

            if (loan == null)
                return ResultViewModel.Error("Loan not found.");

            if (loan.ReturnDate != null)
                return ResultViewModel.Error("Cannot delete a returned loan.");

            loan.Book.IncreaseQuantity();

            await _bookRepository.Update(loan.Book);
            await _loanRepository.Delete(loan.Id);

            return ResultViewModel.Success();
        }
    }
}

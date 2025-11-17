using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.AddLoan
{
    public class AddLoanHandler : IRequestHandler<AddLoanCommand, ResultViewModel<int>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;

        public AddLoanHandler(ILoanRepository loanRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel<int>> Handle(AddLoanCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetById(request.IdBook);

            if (book == null)
                return ResultViewModel<int>.Error("Book not found.");

            var loan = request.ToEntity(book);

            await _loanRepository.Add(loan);

            return ResultViewModel<int>.Success(loan.Id);
        }
    }
}

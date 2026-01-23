using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILoanRepository _loanRepository;

        public DeleteBookHandler(IBookRepository bookRepository, ILoanRepository loanRepository)
        {
            _bookRepository = bookRepository;
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetById(request.Id);

            if (book == null)
                return ResultViewModel.Error("Livro não encontrado.");

            if (book.IsDeleted)
                return ResultViewModel.Error("Este livro já foi excluído.");

            if (await _loanRepository.ExistsActiveLoanForBook(request.Id))
                return ResultViewModel.Error("Você não pode deletar um livro que possui empréstimos ativos.");

            book.SetAsDeleted();
            await _bookRepository.Update(book);

            return ResultViewModel.Success();
        }
    }
}

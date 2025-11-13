using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommand : IRequest<ResultViewModel>
    {
        public DeleteBookCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetById(request.Id);

            if (book == null)
                return ResultViewModel.Error("Book not found.");

            book.SetAsDeleted();
            await _bookRepository.Update(book);

            return ResultViewModel.Success();

        }
    }
}

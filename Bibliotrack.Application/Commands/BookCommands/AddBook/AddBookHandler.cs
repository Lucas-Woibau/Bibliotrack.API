using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Commands.BookCommands.AddBook
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, ResultViewModel<int>>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel<int>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.ToEntity();

            await _bookRepository.Add(book);

            return ResultViewModel<int>.Success(book.Id);
        }
    }
}

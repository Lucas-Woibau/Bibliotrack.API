using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetById(request.IdBook);

            if (book == null)
                return ResultViewModel.Error("Book not found.");

            book.Update(request.Title, request.Author, request.Description, 
                request.Quantity, request.RegistrationDate,request.Catalog);
            await _bookRepository.Update(book);

            return ResultViewModel.Success();
        }
    }
}

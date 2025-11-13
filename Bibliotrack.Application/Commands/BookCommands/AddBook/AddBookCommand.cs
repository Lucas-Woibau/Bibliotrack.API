using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Entities;
using Bibliotrack.Domain.Enums;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Commands.BookCommands.AddBook
{
    public class AddBookCommand : IRequest<ResultViewModel<int>>
    {
        public string Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? Catalog { get; set; }

        public Book ToEntity()
            => new(Title, Author, Description, Quantity, RegistrationDate, Catalog);
    }

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

            var id = await _bookRepository.Add(book);
        }
    }
}

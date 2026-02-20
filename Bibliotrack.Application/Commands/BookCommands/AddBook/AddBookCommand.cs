using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Entities;
using MediatR;

namespace Bibliotrack.Application.Commands.BookCommands.AddBook
{
    public class AddBookCommand : IRequest<ResultViewModel<int>>
    {
        public string Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public string? RegistrationCode { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? Catalog { get; set; }

        public Book ToEntity()
            => new(Title, Author, Description, Quantity, RegistrationCode, RegistrationDate, Catalog);
    }
}

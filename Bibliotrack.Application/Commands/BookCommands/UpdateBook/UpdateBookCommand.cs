using Bibliotrack.Application.Models;
using MediatR;

namespace Bibliotrack.Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommand : IRequest<ResultViewModel>
    {
        public int IdBook { get; set; }
        public string Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public string? RegistrationCode { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? Catalog { get; set; }
    }
}

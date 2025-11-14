using Bibliotrack.Application.Models;
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
}

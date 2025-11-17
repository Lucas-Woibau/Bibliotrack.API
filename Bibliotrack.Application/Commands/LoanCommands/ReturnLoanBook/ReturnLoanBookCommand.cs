using Bibliotrack.Application.Models;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.ReturnLoanBook
{
    public class ReturnLoanBookCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public ReturnLoanBookCommand(int id)
        {
            Id = id;
        }
    }
}

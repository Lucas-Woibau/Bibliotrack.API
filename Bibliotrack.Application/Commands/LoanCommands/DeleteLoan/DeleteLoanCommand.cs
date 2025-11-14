using Bibliotrack.Application.Models;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.DeleteLoan
{
    public class DeleteLoanCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public DeleteLoanCommand(int id)
        {
            Id = id;
        }
    }
}

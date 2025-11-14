using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Entities;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.UpdateLoan
{
    public class UpdateLoanCommand : IRequest<ResultViewModel>
    {
        public int IdLoan { get; set; }
        public Book Book { get; set; }
        public string PersonName { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}

using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Enums;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.UpdateLoan
{
    public class UpdateLoanCommand : IRequest<ResultViewModel>
    {
        public int IdLoan { get; set; }
        public int IdBook { get; set; }
        public string PersonName { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public LoanStatus Status { get; set; }
    }
}

using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Entities;
using Bibliotrack.Domain.Enums;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.AddLoan
{
    public class AddLoanCommand : IRequest<ResultViewModel<int>>
    {
        public int IdBook { get; set; }
        public string PersonName { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ExpectedReturnBook { get; set; }
        public LoanStatus Status { get; set; }

        public Loan ToEntity(Book book)
            => new(IdBook, book, PersonName,LoanDate, ExpectedReturnBook, Status);
    }
}

using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Entities;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.AddLoan
{
    public class AddLoanCommand : IRequest<ResultViewModel<int>>
    {
        public int IdBook { get; set; }
        public string PersonName { get; set; }
        public DateTime LoanDate { get; private set; }
        public DateTime? ExpectedReturnBook { get; set; }

        public Loan ToEntity(Book book)
            => new(IdBook, book, PersonName,LoanDate, ExpectedReturnBook);
    }
}

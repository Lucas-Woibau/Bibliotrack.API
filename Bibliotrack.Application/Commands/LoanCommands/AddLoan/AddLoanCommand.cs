using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Entities;
using MediatR;

namespace Bibliotrack.Application.Commands.LoanCommands.AddLoan
{
    public class AddLoanCommand : IRequest<ResultViewModel<int>>
    {
        public Book Book { get; set; }
        public string PersonName { get; set; }
        public DateTime LoanDate { get; private set; }
        public DateTime? ExpectedReturnBook { get; set; }

        public Loan ToEntity()
            => new(Book, PersonName,LoanDate, ExpectedReturnBook);
    }
}

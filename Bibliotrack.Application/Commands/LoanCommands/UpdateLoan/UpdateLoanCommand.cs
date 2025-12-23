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
        private DateTime LoanDate { get; set; }
        public DateTime LoanDateShort { get; set; }
        public DateTime? ExpectedReturnBook { get; set; }
        public DateTime? ReturnDate { get; set; }

        public void SetIdLoan(int id)
        {
            IdLoan = id;
        }
    }
}

using Bibliotrack.Domain.Entities;
using Bibliotrack.Domain.Enums;

namespace Bibliotrack.Application.Models
{
    public class LoanItemViewModel
    {
        public LoanItemViewModel(int id, string bookTitle, string personName, DateTime loanDate, LoanStatus status)
        {
            Id = id;
            BookTitle = bookTitle;
            PersonName = personName;
            LoanDate = loanDate;
            Status = status;
        }
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string PersonName { get; set; }
        private DateTime? LoanDate { get; set; }
        public string? LoanDateShort
            => LoanDate?.ToString("dd-MM-yyyy");
        public LoanStatus Status { get; set; }

        public static LoanItemViewModel FromEntity(Loan loan)
        {
            var bookTitle = loan.Book?.Title ?? "There is no title.";
            return new(loan.Id, bookTitle, loan.PersonName, loan.LoanDate, loan.Status);
        }
    }
}

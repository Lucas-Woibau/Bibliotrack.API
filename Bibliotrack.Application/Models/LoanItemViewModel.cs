using Bibliotrack.Domain.Entities;

namespace Bibliotrack.Application.Models
{
    public class LoanItemViewModel
    {
        public LoanItemViewModel(int id, string bookTitle, string personName, DateTime loanDate)
        {
            Id = id;
            BookTitle = bookTitle;
            PersonName = personName;
            LoanDate = loanDate;
        }
        public int Id { get; set; }
        public string BookTitle { get;  set; }
        public string PersonName { get;  set; }
        private DateTime? LoanDate { get; set; }
        public string? LoanDateShort
            => LoanDate?.ToString("dd-MM-yyyy");

        public static LoanItemViewModel FromEntity(Loan loan)
        {
            var bookTitle = loan.Book?.Title ?? "There is no title.";
            return new(loan.Id, bookTitle, loan.PersonName, loan.LoanDate);
        }
    }
}

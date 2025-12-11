using Bibliotrack.Domain.Entities;

namespace Bibliotrack.Application.Models
{
    public class LoanItemViewModel
    {
        public LoanItemViewModel(string bookTitle, string personName, DateTime loanDate)
        {
            BookTitle = bookTitle;
            PersonName = personName;
            LoanDate = loanDate;
        }

        public string BookTitle { get; private set; }
        public string PersonName { get; private set; }
        private DateTime? LoanDate { get; set; }
        public string? LoanDateShort
            => LoanDate?.ToString("dd-MM-yyy");

        public static LoanItemViewModel FromEntity(Loan loan)
        {
            var bookTitle = loan.Book?.Title ?? "There is no title.";
            return new(bookTitle, loan.PersonName, loan.LoanDate);
        }
    }
}

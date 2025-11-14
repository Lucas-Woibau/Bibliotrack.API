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
        public DateTime LoanDate { get; private set; }

        public static LoanItemViewModel FromEntity(Loan loan)
        {
            var bookTitle = loan.Book?.Title ?? "There is no title.";
            return new(bookTitle, loan.PersonName, loan.LoanDate);
        }         
    }
}

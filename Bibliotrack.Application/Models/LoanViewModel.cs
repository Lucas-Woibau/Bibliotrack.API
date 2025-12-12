using Bibliotrack.Domain.Entities;

namespace Bibliotrack.Application.Models
{
    public class LoanViewModel
    {
        public LoanViewModel(string bookTitle, string personName, DateTime loanDate, DateTime? expectedReturnBook, DateTime? returnDate)
        {
            BookTitle = bookTitle;
            PersonName = personName;
            LoanDate = loanDate;
            ExpectedReturnBook = expectedReturnBook;
            ReturnDate = returnDate;
        }

        public string BookTitle { get; private set; }
        public string PersonName { get; private set; }
        private DateTime LoanDate { get; set; }
        public string LoanDateShort
            => LoanDate.ToString("dd-MM-yyy");
        private DateTime? ExpectedReturnBook { get; set; }
        public string? ExpectedReturnBookDateShort
            => ExpectedReturnBook?.ToString("dd-MM-yyy");
        private DateTime? ReturnDate { get; set; }
        public string? ReturnDateShort
            => ReturnDate?.ToString("dd-MM-yyy");

        public static LoanViewModel FromEntity(Loan loan)
        {
            var bookTitle = loan.Book?.Title ?? "There is no title.";
            return new(bookTitle, loan.PersonName, loan.LoanDate, loan.ExpectedReturnBook, loan.ReturnDate);
        }
    }
}

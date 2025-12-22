using Bibliotrack.Domain.Entities;
using Bibliotrack.Domain.Enums;

namespace Bibliotrack.Application.Models
{
    public class LoanViewModel
    {
        public LoanViewModel(int id, string bookTitle, string personName, DateTime loanDate, DateTime? expectedReturnBook, DateTime? returnDate, LoanStatus status)
        {
            Id = id;
            BookTitle = bookTitle;
            PersonName = personName;
            LoanDate = loanDate;
            ExpectedReturnBook = expectedReturnBook;
            ReturnDate = returnDate;
            Status = status;
        }
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string PersonName { get; set; }
        private DateTime LoanDate { get; set; }
        public string LoanDateShort
            => LoanDate.ToString("dd-MM-yyy");
        private DateTime? ExpectedReturnBook { get; set; }
        public string? ExpectedReturnBookDateShort
            => ExpectedReturnBook?.ToString("dd-MM-yyy");
        private DateTime? ReturnDate { get; set; }
        public string? ReturnDateShort
            => ReturnDate?.ToString("dd-MM-yyy");
        public LoanStatus Status { get; set; }

        public static LoanViewModel FromEntity(Loan loan)
        {
            var bookTitle = loan.Book?.Title ?? "There is no title.";
            return new(loan.Id, bookTitle, loan.PersonName, loan.LoanDate, loan.ExpectedReturnBook, loan.ReturnDate, loan.Status);
        }
    }
}

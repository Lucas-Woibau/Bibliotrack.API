namespace Bibliotrack.Domain.Entities
{
    public class Loan : BaseEntity
    {
        protected Loan() { }
        public Loan(Book book, string personName, DateTime loanDate, DateTime? expectedReturnBook)
        {
            Book = book;
            PersonName = personName;
            ExpectedReturnBook = expectedReturnBook;
            LoanDate = loanDate;
        }

        public Book Book { get; private set; }
        public string PersonName { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime? ExpectedReturnBook { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public void Update(Book book, string personName, DateTime loanDate, DateTime? returnDate)
        {
            Book = book;
            PersonName = personName;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }
    }
}

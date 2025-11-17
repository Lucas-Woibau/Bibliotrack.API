namespace Bibliotrack.Domain.Entities
{
    public class Loan : BaseEntity
    {
        protected Loan() { }
        public Loan(int idBook, Book book, string personName, DateTime loanDate, DateTime? expectedReturnBook)
        {
            IdBook = idBook;
            Book = book;
            PersonName = personName;
            ExpectedReturnBook = expectedReturnBook;
            LoanDate = loanDate;
        }
        public int IdBook { get; set; }
        public Book Book { get; private set; }
        public string PersonName { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime? ExpectedReturnBook { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public bool IsReturned => ReturnDate.HasValue;

        public bool Lend()
        {
            if (LoanDate != default)
                return false;

            LoanDate = DateTime.Now;

            Book.DecreaseQuantity();
            Book.UpdateStatusBasedOnQuantity();

            return true;
        }

        public bool ReturnLoan()
        {
            if (IsReturned)
                return false;

            ReturnDate = DateTime.Now;

            Book.IncreaseQuantity();
            Book.UpdateStatusBasedOnQuantity();

            return true;
        }

        public void Update(int idBook, Book book, string personName, DateTime loanDate, DateTime? returnDate)
        {
            IdBook = idBook;
            Book = book;
            PersonName = personName;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }
    }
}

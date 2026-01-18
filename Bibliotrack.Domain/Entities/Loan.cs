using Bibliotrack.Domain.Enums;

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

            Status = LoanStatus.Emprestado;
        }
        public int IdBook { get; set; }
        public Book Book { get; private set; }
        public string PersonName { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime? ExpectedReturnBook { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public LoanStatus Status { get; private set; }

        public bool Lend()
        {
            if (LoanDate != default)
                return false;

            LoanDate = DateTime.Now;
            Status = LoanStatus.Emprestado;

            Book.DecreaseQuantity();
            Book.UpdateStatusBasedOnQuantity();

            return true;
        }

        public bool ReturnLoan()
        {
            if (IsReturned())
                return false;

            MarkAsReturned(DateTime.Now);
            return true;
        }

        public bool IsReturned()
        {
            return ReturnDate.HasValue;
        }

        private void MarkAsReturned(DateTime returnDate)
        {
            ReturnDate = returnDate;
            Status = LoanStatus.Devolvido;

            Book.IncreaseQuantity();
            Book.UpdateStatusBasedOnQuantity();
        }


        public void Update(int idBook, Book book, string personName, DateTime loanDate, DateTime? expectedReturnBook, DateTime? returnDate)
        {
            IdBook = idBook;
            Book = book;
            PersonName = personName;
            LoanDate = loanDate;
            ExpectedReturnBook = expectedReturnBook;

            if (returnDate.HasValue)
            {
                if (!IsReturned())
                {
                    MarkAsReturned(returnDate.Value);
                }
                else
                {
                    ReturnDate = returnDate;
                    Status = LoanStatus.Devolvido;
                }
            }

            if (!returnDate.HasValue && IsReturned())
            {
                ReturnDate = null;
                Status = LoanStatus.Emprestado;

                Book.DecreaseQuantity();
                Book.UpdateStatusBasedOnQuantity();
            }
        }
    }
}

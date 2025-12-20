using Bibliotrack.Domain.Enums;

namespace Bibliotrack.Domain.Entities
{
    public class Book : BaseEntity
    {
        protected Book() { }
        public Book(string title, string? author, string? description, int quantity, DateTime? registrationDate, string? catalog)
            : base()
        {
            Title = title;
            Author = author;
            Description = description;
            Quantity = quantity;
            RegistrationDate = registrationDate;
            Catalog = catalog;

            UpdateStatusBasedOnQuantity();
        }

        public string Title { get; private set; }
        public string? Author { get; private set; }
        public string? Description { get; private set; }
        public int Quantity { get; private set; }
        public DateTime? RegistrationDate { get; private set; }
        public string? Catalog { get; private set; }
        public BookStatus Status { get; private set; }

        public bool VerifyIfHaslQuantity()
        {
            if (Quantity > 0)
                return true;

            return false;
        }

        public void UpdateStatusBasedOnQuantity()
        {
            if (VerifyIfHaslQuantity())
            {
                Status = BookStatus.Disponível;
            }
            else
            {
                Status = BookStatus.Indisponível;
            }
        }

        public void IncreaseQuantity()
        {
            Quantity++;
        }

        public bool DecreaseQuantity()
        {
            if (Quantity == 0)
                return false;

            Quantity--;
            return true;
        }


        public void Update(string title, string? author, string? description, int quantity, DateTime? registrationDate, string? catalog)
        {
            Title = title;
            Author = author;
            Description = description;
            Quantity = quantity;
            RegistrationDate = registrationDate;
            Catalog = catalog;
        }
    }
}

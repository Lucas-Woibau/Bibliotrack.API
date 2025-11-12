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

            SetAvailable();
        }

        public string Title { get; private set; }
        public string? Author { get; private set; }
        public string? Description { get; private set; }
        public int Quantity { get; private set; }
        public DateTime? RegistrationDate { get; private set; }
        public string? Catalog { get; private set; }
        public BookStatus Status { get; private set; }

        public bool SetAvailable()
        {
            Status = BookStatus.Available;
            return true;
        }
        public bool SetUnavailable()
        {
            Status = BookStatus.Unavailable;
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

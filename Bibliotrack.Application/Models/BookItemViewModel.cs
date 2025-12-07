using Bibliotrack.Domain.Entities;
using Bibliotrack.Domain.Enums;

namespace Bibliotrack.Application.Models
{
    public class BookItemViewModel
    {
        public BookItemViewModel(string title, string? author, string? description,
            int quantity, DateTime? registrationDate, string catalog, BookStatus status)
        {
            Title = title;
            Author = author;
            Description = description;
            Quantity = quantity;
            RegistrationDate = registrationDate;
            Catalog = catalog;
            Status = status;
        }

        public string Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public DateTime? RegistrationDate { get ; set; }
        public string? RegistrationDateShort
            => RegistrationDate?.ToString("dd-MM-yyy");

        public string Catalog { get; set; }
        public BookStatus Status { get; set; }

        public static BookItemViewModel FromEntity(Book book)
        {
           return new(book.Title, book.Author, book.Description,book.Quantity,book.RegistrationDate,book.Catalog, book.Status);
        }
    }
}

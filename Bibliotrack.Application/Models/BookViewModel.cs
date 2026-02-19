using Bibliotrack.Domain.Entities;
using Bibliotrack.Domain.Enums;

namespace Bibliotrack.Application.Models
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string? author, string? description, 
            int quantity, int? registrationNumber, DateTime? registrationDate, string? catalog, BookStatus status)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
            Quantity = quantity;
            RegistrationNumber = registrationNumber;
            RegistrationDate = registrationDate;
            Catalog = catalog;
            Status = status;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int? RegistrationNumber { get; set; }
        private DateTime? RegistrationDate { get; set; }
        public string? RegistrationDateShort
            => RegistrationDate?.ToString("dd-MM-yyy");
        public string? Catalog { get; set; }
        public BookStatus Status { get; set; }

        public static BookViewModel FromEntity(Book book)
            => new(book.Id, book.Title, book.Author, book.Description, book.Quantity, book.RegistrationNumber, book.RegistrationDate, book.Catalog, book.Status);
    }
}

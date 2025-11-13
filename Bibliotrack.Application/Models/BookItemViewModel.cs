using Bibliotrack.Domain.Entities;
using Bibliotrack.Domain.Enums;

namespace Bibliotrack.Application.Models
{
    public class BookItemViewModel
    {
        public BookItemViewModel(string title, string? author, BookStatus status)
        {
            Title = title;
            Author = author;
            Status = status;
        }

        public string Title { get; set; }
        public string? Author { get; set; }
        public BookStatus Status { get; set; }

        public static BookItemViewModel FromEntity(Book book)
            => new (book.Title, book.Author, book.Status);
    }
}

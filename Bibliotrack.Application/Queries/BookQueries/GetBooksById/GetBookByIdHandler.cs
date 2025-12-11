using Bibliotrack.Application.Common;
using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;

namespace Bibliotrack.Application.Queries.Book.GetBooksById
{
    public class GetBookByIdHandler : IHandler<GetBookByIdQuery, ResultViewModel<BookViewModel>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel<BookViewModel>> HandleAsync(GetBookByIdQuery request)
        {
            var book = await _bookRepository.GetById(request.Id);

            if (book == null)
                return ResultViewModel<BookViewModel>.Error("Book not found.");

            var model = BookViewModel.FromEntity(book);

            return ResultViewModel<BookViewModel>.Success(model);
        }
    }
}

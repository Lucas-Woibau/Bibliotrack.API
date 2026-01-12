using Bibliotrack.Application.Models;
using Bibliotrack.Application.Queries.Book.GetAllBooks;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Queries.BookQueries.GetBooksToLoan
{
    public class GetBooksToLoanHandler : IRequestHandler<GetAllBooksQuery, ResultViewModel<List<BookItemViewModel>>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksToLoanHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel<List<BookItemViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAll(request.Search);

            var model = books.Select(BookItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<BookItemViewModel>>.Success(model);
        }
    }
}

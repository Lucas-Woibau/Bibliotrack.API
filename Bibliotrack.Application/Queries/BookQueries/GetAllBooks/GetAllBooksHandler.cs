using Bibliotrack.Application.Models;
using Bibliotrack.Application.Queries.BookQueries.GetBooksToLoan;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Queries.Book.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetBooksToLoanQuery, ResultViewModel<List<BookItemViewModel>>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel<List<BookItemViewModel>>> Handle(GetBooksToLoanQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooksToLoan(request.Search);

            var model = books.Select(BookItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<BookItemViewModel>>.Success(model);
        }
    }
}

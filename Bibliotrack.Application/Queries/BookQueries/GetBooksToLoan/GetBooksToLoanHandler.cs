using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Queries.BookQueries.GetBooksToLoan
{
    public class GetBooksToLoanHandler : IRequestHandler<GetBooksToLoanQuery, ResultViewModel<List<BookItemViewModel>>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksToLoanHandler(IBookRepository bookRepository)
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

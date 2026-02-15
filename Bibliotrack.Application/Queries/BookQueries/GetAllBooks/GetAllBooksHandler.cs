using Bibliotrack.Application.Models;
using Bibliotrack.Application.Queries.BookQueries.GetBooksToLoan;
using Bibliotrack.Domain.Common.Pagination;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Queries.Book.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, ResultViewModel<PagedResult<BookItemViewModel>>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel<PagedResult<BookItemViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var pagedBooks = await _bookRepository.GetAll(request.Search, request.Page, request.Size);

            var items = pagedBooks.Items.Select(BookItemViewModel.FromEntity).ToList();

            var pagedVm = new PagedResult<BookItemViewModel>(
                items,
                pagedBooks.PageNumber,
                pagedBooks.PageSize,
                pagedBooks.TotalRecords
            );

            return ResultViewModel<PagedResult<BookItemViewModel>>.Success(pagedVm);
        }
    }
}

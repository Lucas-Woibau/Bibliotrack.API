using Bibliotrack.Application.Models;
using Bibliotrack.Domain.Common.Pagination;
using Bibliotrack.Domain.Repositories;
using MediatR;

namespace Bibliotrack.Application.Queries.LoanQueries.GetAllLoans
{
    public class GetAllLoansHandler : IRequestHandler<GetAllLoansQuery, ResultViewModel<PagedResult<LoanItemViewModel>>>
    {
        private readonly ILoanRepository _loanRepository;

        public GetAllLoansHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel<PagedResult<LoanItemViewModel>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var pagedLoans = await _loanRepository.GetAll(request.Search, request.Page, request.Size);

            var items = pagedLoans.Items.Select(LoanItemViewModel.FromEntity).ToList();

            var pagedVm = new PagedResult<LoanItemViewModel>(
                items,
                pagedLoans.PageNumber,
                pagedLoans.PageSize,
                pagedLoans.TotalRecords
            );

            return ResultViewModel<PagedResult<LoanItemViewModel>>.Success(pagedVm);
        }
    }
}

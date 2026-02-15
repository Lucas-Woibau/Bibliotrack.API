using Bibliotrack.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace Bibliotrack.Application.Queries.BookQueries.GetBooksToLoan
{
    public class GetBooksToLoanQuery : IRequest<ResultViewModel<List<BookItemViewModel>>>
    {
        public string Search { get; }

        public GetBooksToLoanQuery(string search)
        {
            Search = search;
        }
    }
}

using Bibliotrack.Application.Commands.LoanCommands.DeleteLoan;
using Bibliotrack.Domain.Enums;
using Bibliotrack.Domain.Repositories;
using FluentValidation;

namespace Bibliotrack.Application.Validators
{
    public class DeleteBookValidator : AbstractValidator<DeleteLoanCommand>
    {
        public DeleteBookValidator(ILoanRepository loanRepository)
        {
            RuleFor(x => x.Id)
                .MustAsync(async (bookId, ct) =>
                    !await loanRepository.ExistsActiveLoanForBook(bookId))
                .WithMessage("Você não pode deletar um livro que possui empréstimos ativos.");
        }
    }
}

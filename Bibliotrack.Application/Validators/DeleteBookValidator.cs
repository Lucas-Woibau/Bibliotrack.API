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
            RuleFor(l => l.Id)
                .MustAsync(async (id, cancellation) =>
                {
                    var loan = await loanRepository.GetById(id);
                    return loan.Status == LoanStatus.Emprestado;
                })
                .WithMessage("Empréstimos já devolvidos não pode ser deletado.");
        }
    }
}

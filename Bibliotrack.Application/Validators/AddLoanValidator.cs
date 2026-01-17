using Bibliotrack.Application.Commands.LoanCommands.AddLoan;
using FluentValidation;

namespace Bibliotrack.Application.Validators
{
    public class AddLoanValidator : AbstractValidator<AddLoanCommand>
    {
        public AddLoanValidator()
        {
            RuleFor(l => l.LoanDate)
                .NotEmpty()
                    .WithMessage("Deve ter uma data de empréstimo")
                .Must(d => d <= DateTime.UtcNow)
                    .WithMessage("A data de empréstimo não pode ser no futuro");

            RuleFor(l => l.ExpectedReturnBook)
                .Must((loan, expectedReturn) => expectedReturn >= loan.LoanDate)
                    .When(l => l.ExpectedReturnBook.HasValue)
                        .WithMessage("A data de retorno não pode ser antes da data de empréstimo");
        }
    }
}

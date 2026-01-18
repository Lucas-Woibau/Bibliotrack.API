using Bibliotrack.Application.Commands.LoanCommands.UpdateLoan;
using FluentValidation;

namespace Bibliotrack.Application.Validators
{
    public class UpdateLoanValidator : AbstractValidator<UpdateLoanCommand>
    {
        public UpdateLoanValidator()
        {
            RuleFor(l => l.LoanDate)
                .NotEmpty()
                    .WithMessage("Deve ter uma data de empréstimo")
                .Must(d => d <= DateTime.UtcNow)
                    .WithMessage("A data de empréstimo não pode ser no futuro");

            RuleFor(l => l.ExpectedReturnBook)
                .Must((loan, expectedReturn) => expectedReturn >= loan.LoanDate)
                    .When(l => l.ExpectedReturnBook.HasValue)
                        .WithMessage("A data esperada de retorno esperado não pode ser antes da data de empréstimo");

            RuleFor(l => l.ReturnDate)
                .Must((loan, returnDate) => returnDate >= loan.LoanDate)
                    .When(l => l.ReturnDate.HasValue)
                        .WithMessage("A data de retorno não pode ser antes da data de empréstimo");

            RuleFor(l => l.ReturnDate)
                .Must(d => d <= DateTime.UtcNow || !d.HasValue)
                    .WithMessage("A data de devolução não pode ser no futuro");
        }
    }
}

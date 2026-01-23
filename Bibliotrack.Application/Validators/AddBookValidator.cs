using Bibliotrack.Application.Commands.BookCommands.AddBook;
using FluentValidation;

namespace Bibliotrack.Application.Validators
{
    public class AddBookValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookValidator()
        {
            RuleFor(b => b.Quantity)
                .GreaterThan(0)
                .WithMessage("A quantidade deve ser maior que 0.");

            RuleFor(b => b.RegistrationDate)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("A data de registro não pode ser no futuro.");
        }
    }
}

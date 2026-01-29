using Bibliotrack.Application.Commands.BookCommands.UpdateBook;
using FluentValidation;

namespace Bibliotrack.Application.Validators
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookValidator()
        {
            RuleFor(b => b.RegistrationDate)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("A data de registro não pode ser no futuro.");
        }
    }
}

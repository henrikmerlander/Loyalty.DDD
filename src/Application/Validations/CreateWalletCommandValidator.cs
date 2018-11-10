using Application.Commands;
using FluentValidation;

namespace Application.Validations
{
    public class CreateWalletCommandValidator : AbstractValidator<CreateWalletCommand>
    {
        public CreateWalletCommandValidator()
        {
            RuleFor(command => command.UserName).NotEmpty();
        }
    }
}

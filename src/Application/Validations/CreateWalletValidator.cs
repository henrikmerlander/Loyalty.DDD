using Application.Commands;
using FluentValidation;

namespace Application.Validations
{
    public class CreateWalletValidator : AbstractValidator<CreateWallet>
    {
        public CreateWalletValidator()
        {
            RuleFor(command => command.UserName).NotEmpty();
        }
    }
}

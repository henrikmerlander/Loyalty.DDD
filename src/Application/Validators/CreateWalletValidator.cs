using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class CreateWalletValidator : AbstractValidator<CreateWallet>
    {
        public CreateWalletValidator()
        {
            RuleFor(command => command.UserName).NotEmpty();
        }
    }
}

using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class RedeemPointsValidator : AbstractValidator<RedeemPoints>
    {
        public RedeemPointsValidator()
        {
            RuleFor(command => command.Points).GreaterThan(0);
        }
    }
}

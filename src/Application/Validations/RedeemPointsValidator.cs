using Application.Commands;
using FluentValidation;

namespace Application.Validations
{
    public class RedeemPointsValidator : AbstractValidator<RedeemPoints>
    {
        public RedeemPointsValidator()
        {
            RuleFor(command => command.Points).GreaterThan(0);
        }
    }
}

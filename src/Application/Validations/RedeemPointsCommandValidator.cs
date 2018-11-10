using Application.Commands;
using FluentValidation;

namespace Application.Validations
{
    public class RedeemPointsCommandValidator : AbstractValidator<RedeemPointsCommand>
    {
        public RedeemPointsCommandValidator()
        {
            RuleFor(command => command.Points).GreaterThan(0);
        }
    }
}

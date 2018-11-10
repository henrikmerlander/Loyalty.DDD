using Application.Commands;
using FluentValidation;

namespace Application.Validations
{
    public class AccruePointsValidator : AbstractValidator<AccruePoints>
    {
        public AccruePointsValidator()
        {
            RuleFor(command => command.Points).GreaterThan(0);
        }
    }
}

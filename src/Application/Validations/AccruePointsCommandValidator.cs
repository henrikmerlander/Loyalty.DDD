using Application.Commands;
using FluentValidation;

namespace Application.Validations
{
    public class AccruePointsCommandValidator : AbstractValidator<AccruePointsCommand>
    {
        public AccruePointsCommandValidator()
        {
            RuleFor(command => command.Points).GreaterThan(0);
        }
    }
}

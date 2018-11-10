using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Behaviors
{
    public class ValidatingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;
        public ValidatingBehavior(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                throw new ValidationError(
                    $"Command Validation Errors for type {typeof(TRequest).Name}", new ValidationException("Validation error", failures));
            }

            var response = await next();
            return response;
        }
    }
}

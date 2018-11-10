using System;

namespace Domain.Exceptions
{
    public class ValidationError : DomainExceptionBase
    {
        public ValidationError(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

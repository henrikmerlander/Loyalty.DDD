using System;
using Domain.Exceptions.Seedwork;

namespace Domain.Exceptions.Seedwork
{
    public class ValidationError : DomainException
    {
        public ValidationError(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

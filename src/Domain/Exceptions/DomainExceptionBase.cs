using System;

namespace Domain.Exceptions
{
    public abstract class DomainExceptionBase : Exception
    {
        public DomainExceptionBase()
        { }

        public DomainExceptionBase(string message)
            : base(message)
        { }

        public DomainExceptionBase(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

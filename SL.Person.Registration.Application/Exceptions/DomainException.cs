using SL.Person.Registration.Application.Results.Base;
using System;

namespace SL.Person.Registration.Application.Exceptions
{
    public class DomainException : Exception
    {
        public ResultBase Result { get; }

        public DomainException(ResultBase resultBase)
            => Result = resultBase;
    }
}

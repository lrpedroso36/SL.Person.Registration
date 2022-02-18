using SL.Person.Registration.Domain.Results;
using System;

namespace SL.Person.Registration.Application.Exceptions
{
    public class HttpRequestException : Exception
    {
        public ResultBase Result { get; }

        public HttpRequestException(ResultBase resultBase)
            => Result = resultBase;
    }
}

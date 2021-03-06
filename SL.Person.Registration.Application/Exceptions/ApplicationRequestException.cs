using SL.Person.Registration.Application.Results.Base;
using System;

namespace SL.Person.Registration.Application.Exceptions
{
    public class ApplicationRequestException : Exception
    {
        public ResultBase Result { get; }

        public ApplicationRequestException(ResultBase resultBase)
            => Result = resultBase;
    }
}

using SL.Person.Registration.Application.Commons.Responses.Base;
using System;

namespace SL.Person.Registration.Application.Commons.Exceptions;

public class DomainException : Exception
{
    public ResponseBase Result { get; }

    public DomainException(ResponseBase resultBase)
        => Result = resultBase;
}

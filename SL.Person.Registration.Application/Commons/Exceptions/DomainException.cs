using SL.Person.Registration.Application.Commons.Responses.Base;
using System;

namespace SL.Person.Registration.Application.Commons.Exceptions;

public class DomainException : Exception
{
    public ResultBase Result { get; }

    public DomainException(ResultBase resultBase)
        => Result = resultBase;
}

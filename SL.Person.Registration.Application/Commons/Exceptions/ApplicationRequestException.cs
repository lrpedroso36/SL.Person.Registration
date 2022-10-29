using SL.Person.Registration.Application.Commons.Responses.Base;
using System;

namespace SL.Person.Registration.Application.Commons.Exceptions;

public class ApplicationRequestException : Exception
{
    public ResultBase Result { get; }

    public ApplicationRequestException(ResultBase resultBase)
        => Result = resultBase;
}

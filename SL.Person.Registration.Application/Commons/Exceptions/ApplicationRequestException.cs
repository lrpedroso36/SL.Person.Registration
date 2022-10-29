using SL.Person.Registration.Application.Commons.Responses.Base;
using System;

namespace SL.Person.Registration.Application.Commons.Exceptions;

public class ApplicationRequestException : Exception
{
    public ResponseBase Result { get; }

    public ApplicationRequestException(ResponseBase resultBase)
        => Result = resultBase;
}

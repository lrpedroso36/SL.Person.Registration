using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;
using System;

namespace SL.Person.Registration.Application.Command.Precence;

public static class PrecenceCommandValidation
{
    public static void RequestValidate(this PrecenceCommand request)
    {
        if (!Guid.TryParse(request.Id, out Guid id))
        {
            var result = new Result();
            result.SetErrorType(ErrorType.InvalidParameters);
            result.AddErrors(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid);
            throw new ApplicationRequestException(result);
        }
    }
}

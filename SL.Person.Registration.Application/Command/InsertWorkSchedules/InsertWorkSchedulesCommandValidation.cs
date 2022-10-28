using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;
using System;

namespace SL.Person.Registration.Application.Command.InsertWorkSchedules;

public static class InsertWorkSchedulesCommandValidation
{
    public static void RequestValidate(this InsertWorkSchedulesCommand request)
    {
        if (!Guid.TryParse(request.Id, out Guid id) || request.Works.Count == 0)
        {
            var result = new Result();
            result.SetErrorType(ErrorType.InvalidParameters);
            result.AddErrors(ResourceMessagesValidation.InsertWorkSchedulesCommand_RequestInvalid);
            throw new ApplicationRequestException(result);
        }
    }
}

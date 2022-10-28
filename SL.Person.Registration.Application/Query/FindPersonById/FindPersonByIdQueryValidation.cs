using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;
using System;

namespace SL.Person.Registration.Application.Query.FindPersonById;

public static class FindPersonByIdQueryValidation
{
    public static void RequestValidate(this FindPersonByIdQuery request)
    {
        if (!Guid.TryParse(request.Id, out Guid id))
        {
            var result = new ResultEntities<FindPersonResult>();
            result.SetErrorType(ErrorType.InvalidParameters);
            result.AddErrors(ResourceMessagesValidation.FindPersonByIdValidation_RequestInvalid);
            throw new ApplicationRequestException(result);
        }
    }
}

using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query.FindPeople;

public static class FindPeopleQueryValidation
{
    public static void RequestValidate(this FindPeopleQuery request)
    {
        if (string.IsNullOrWhiteSpace(request.Name) && request.DocumentNumber == 0 && !request.PersonType.HasValue)
        {
            var result = new ResultEntities<IEnumerable<FindPersonResult>>();
            result.SetErrorType(ErrorType.InvalidParameters);
            result.AddErrors(ResourceMessagesValidation.FindPeopleQueryValidation_RequestInvalid);
            throw new ApplicationRequestException(result);
        }
    }
}

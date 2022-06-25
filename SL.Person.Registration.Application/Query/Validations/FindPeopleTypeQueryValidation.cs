using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query.Validations
{
    public static class FindPeopleTypeQueryValidation
    {
        public static void RequestValidate(this FindPeopleTypeQuery request)
        {
            if (request.Type == 0)
            {
                var result = new ResultEntities<IEnumerable<FindPersonResult>>();
                result.SetErrorType(ErrorType.InvalidParameters);
                result.AddErrors(ResourceMessagesValidation.FindPeopleTypeQueryValidation_RequestInvalid);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

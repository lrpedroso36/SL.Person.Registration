using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query.Validations
{
    public static class FindPeopleQueryValidation
    {
        public static void RequestValidate(this FindPeopleQuery request)
        {
            if (string.IsNullOrWhiteSpace(request.Parameter))
            {
                var result = new ResultEntities<IEnumerable<FindPersonResult>>();
                result.SetErrorType(ErrorType.InvalidParameters);
                result.AddErrors(ResourceMessagesValidation.FindPeopleQueryValidation_RequestInvalid);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

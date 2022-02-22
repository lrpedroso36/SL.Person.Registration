using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query.Validations
{
    public static class FindPersonByNameQueryValidation
    {
        public static void RequestValidate(this FindPersonByNameQuery request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                var result = new ResultEntities<IEnumerable<FindPersonResult>>();
                result.SetErrorType(ErrorType.InvalidParameters);
                result.AddErrors(ResourceMessagesValidation.FindPersonByNameQueryValidation_RequestInvalid);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query.Validations
{
    public static class FindPersonByNameQueryValidation
    {
        public static ResultEntities<IEnumerable<FindPersonResult>> RequestValidate(this FindPersonByNameQuery request)
        {
            var result = new ResultEntities<IEnumerable<FindPersonResult>>();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                result.AddErrors(ResourceMessagesValidation.FindPersonByNameQueryValidation_RequestInvalid, ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}

using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Query.Validations
{
    public static class FindPersonByDocumentQueryValidation
    {
        public static ResultBase RequestValidate(this FindPersonByDocumentQuery request)
        {
            var result = new ResultEntities<FindPersonResult>();

            if (request.DocumentNumber == 0)
            {
                result.AddErrors(ResourceMessagesValidation.FindPersonByDocumentQueryValidation_RequestInvalid, ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}

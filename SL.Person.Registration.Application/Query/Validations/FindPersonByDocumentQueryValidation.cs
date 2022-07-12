using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;

namespace SL.Person.Registration.Application.Query.Validations
{
    public static class FindPersonByDocumentQueryValidation
    {
        public static void RequestValidate(this FindPersonByDocumentQuery request)
        {
            if (request.DocumentNumber == 0)
            {
                var result = new ResultEntities<FindPersonResult>();
                result.SetErrorType(ErrorType.InvalidParameters);
                result.AddErrors(ResourceMessagesValidation.FindPersonByDocumentQueryValidation_RequestInvalid);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

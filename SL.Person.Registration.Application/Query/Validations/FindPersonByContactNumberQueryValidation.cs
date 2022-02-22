using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Query.Validations
{
    public static class FindPersonByContactNumberQueryValidation
    {
        public static void RequestValidate(this FindPersonByContactNumberQuery request)
        {
            if (request.Ddd == 0 || request.PhoneNumber == 0)
            {
                var result = new ResultEntities<FindPersonResult>();
                result.SetErrorType(ErrorType.InvalidParameters);
                result.AddErrors(ResourceMessagesValidation.FindPersonByContactNumberQueryValidation_RequestInvalid);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

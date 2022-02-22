using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Query.Validations
{
    public static class FindAddressByZipCodeQueryValidation
    {
        public static void RequestValidate(this FindAddressByZipCodeQuery request)
        {
            if (string.IsNullOrWhiteSpace(request.ZipCode))
            {
                var result = new ResultEntities<Address>();
                result.SetErrorType(ErrorType.InvalidParameters);
                result.AddErrors(ResourceMessagesValidation.FindAddressByZipCodeValidation_RequestInvalid);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

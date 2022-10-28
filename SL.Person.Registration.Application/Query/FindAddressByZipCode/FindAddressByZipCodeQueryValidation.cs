using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;
using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Application.Query.FindAddressByZipCode;

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

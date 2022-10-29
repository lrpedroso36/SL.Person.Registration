using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Commons.Responses.Enums;
using SL.Person.Registration.CrossCuting.Resources;
using SL.Person.Registration.Domain.External.Response;
using SL.Person.Registration.Domain.External.Response.Validations;
using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Application.Query.FindAddressByZipCode.Extensions;

public static class FindAddressByZipCodeExtensions
{
    public static void RequestValidate(this FindAddressByZipCodeQuery request)
    {
        if (string.IsNullOrWhiteSpace(request.ZipCode))
        {
            var result = new ResponseEntities<Address>();
            result.ToInvalidParameter(ResourceMessagesValidation.FindAddressByZipCodeValidation_RequestInvalid);
            throw new ApplicationRequestException(result);
        }
    }

    public static void ValidateInstance(this AddressResponse addressResponse)
    {
        var validation = new AddressResponseInstanceValidation()
            .Validate(addressResponse);

        if (!validation.IsValid)
        {
            var result = new Response();
            result.SetErrorType(ErrorType.NotFoundData);
            validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage));
            throw new ApplicationRequestException(result);
        }
    }
}

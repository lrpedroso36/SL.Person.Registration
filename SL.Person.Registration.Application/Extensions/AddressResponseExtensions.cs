using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;
using SL.Person.Registration.Domain.External.Response;
using SL.Person.Registration.Domain.External.Response.Validations;

namespace SL.Person.Registration.Application.Extensions;

public static class AddressResponseExtensions
{
    public static void ValidateInstance(this AddressResponse addressResponse)
    {
        var validation = new AddressResponseInstanceValidation()
            .Validate(addressResponse);

        if (!validation.IsValid)
        {
            var result = new Result();
            result.SetErrorType(ErrorType.NotFoundData);
            validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage));
            throw new ApplicationRequestException(result);
        }
    }
}
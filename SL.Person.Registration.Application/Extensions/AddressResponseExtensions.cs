using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.External.Response;
using SL.Person.Registration.Domain.External.Response.Validations;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Extensions
{
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
}

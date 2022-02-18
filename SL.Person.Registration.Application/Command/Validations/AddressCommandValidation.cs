using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class AddressCommandValidation
    {
        public static void RequestValidate(this AddressCommand request)
        {
            var result = new Result();
            result.SetErrorType(ErrorType.InvalidParameters);

            if (request.DocumentNumber == 0)
            {
                result.AddErrors(ResourceMessagesValidation.AddressCommandValidation_RequestInvalid_Document);
                throw new ApplicationRequestException(result);
            }

            if (request.Address == null)
            {
                result.AddErrors(ResourceMessagesValidation.AddressCommandValidation_RequestInvalid);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

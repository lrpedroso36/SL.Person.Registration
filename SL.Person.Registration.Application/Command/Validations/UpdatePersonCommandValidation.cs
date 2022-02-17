using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class UpdatePersonCommandValidation
    {
        public static ResultBase RequestValidate(this UpdatePersonCommand request)
        {
            var result = new Result();

            if (request.Person == null || request.Person.DocumentNumber == 0)
            {
                result.AddErrors(ResourceMessagesValidation.UpdatePersonCommandValidation_RequestInvalid, ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}

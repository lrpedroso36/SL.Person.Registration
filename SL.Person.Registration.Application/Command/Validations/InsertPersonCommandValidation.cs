using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class InsertPersonCommandValidation
    {
        public static Result<bool> RequestValidate(this InsertPersonCommand request)
        {
            var result = new Result<bool>();

            if (request.Person == null || request.Person.DocumentNumber == 0)
            {
                result.AddErrors(ResourceMessagesValidation.InsertPersonCommandValidation_RequestInvalid, ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}

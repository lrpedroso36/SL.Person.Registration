using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class InsertPersonCommandValidation
    {
        public static void RequestValidate(this InsertPersonCommand request)
        {
            var result = new Result();

            if (request.Person == null || request.Person.DocumentNumber == 0)
            {
                result.AddErrors(ResourceMessagesValidation.InsertPersonCommandValidation_RequestInvalid, ErrorType.InvalidParameters);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class InsertPersonCommandValidation
    {
        public static void RequestValidate(this InsertPersonCommand request)
        {
            if (request.Person == null || request.Person.DocumentNumber == 0)
            {
                var result = new Result();
                result.SetErrorType(ErrorType.InvalidParameters);
                result.AddErrors(ResourceMessagesValidation.InsertPersonCommandValidation_RequestInvalid);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

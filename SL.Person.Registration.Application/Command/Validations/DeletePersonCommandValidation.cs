using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class DeletePersonCommandValidation
    {
        public static void RequestValidate(this DeletePersonCommand request)
        {
            if (request.DocumentNumber == 0)
            {
                var result = new Result();
                result.SetErrorType(ErrorType.InvalidParameters);
                result.AddErrors(ResourceMessagesValidation.DeletePersonCommandValidation_RequestInvalid);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

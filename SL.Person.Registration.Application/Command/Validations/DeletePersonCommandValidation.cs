using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;
using System;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class DeletePersonCommandValidation
    {
        public static void RequestValidate(this DeletePersonCommand request)
        {
            if (!Guid.TryParse(request.Id, out Guid id))
            {
                var result = new Result();
                result.SetErrorType(ErrorType.InvalidParameters);
                result.AddErrors(ResourceMessagesValidation.DeletePersonCommandValidation_RequestInvalid);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

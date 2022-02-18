using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class ContactCommandValidation
    {
        public static void RequestValidate(this ContactCommand request)
        {
            var result = new Result();

            if (request.DocumentNumber == 0)
            {
                result.AddErrors(ResourceMessagesValidation.ContactCommandValidation_RequestInvalid_Document, ErrorType.InvalidParameters);
                throw new ApplicationRequestException(result);
            }

            if (request.Contact == null)
            {
                result.AddErrors(ResourceMessagesValidation.ContactCommandValidation_RequestInvalid, ErrorType.InvalidParameters);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

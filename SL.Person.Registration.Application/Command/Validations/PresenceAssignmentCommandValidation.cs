using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class PresenceAssignmentCommandValidation
    {
        public static void RequestValidate(this PresenceAssignmentCommand request)
        {
            if (request.LaborerDocument == 0)
            {
                var result = new Result();
                result.SetErrorType(ErrorType.InvalidParameters);
                result.AddErrors(ResourceMessagesValidation.PresenceAssignmentCommandValidation_RequestInvalid_Document);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class InsertOrUpdateContactCommandValidation
    {
        public static Result<bool> RequestValidate(this InsertOrUpdateContactCommand request)
        {
            var result = new Result<bool>();

            if (request.DocumentNumber == 0)
            {
                result.AddErrors(ResourceMessagesValidation.InsertOrUpdateContactCommandValidation_RequestInvalid_Document, ErrorType.InvalidParameters);
                return result;
            }

            if(request.Contact == null)
            {
                result.AddErrors(ResourceMessagesValidation.InsertOrUpdateContactCommandValidation_RequestInvalid, ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}

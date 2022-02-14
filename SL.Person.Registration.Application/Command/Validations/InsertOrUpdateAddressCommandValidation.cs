using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class InsertOrUpdateAddressCommandValidation
    {
        public static Result<bool> RequestValidate(this InsertOrUpdateAddressCommand request)
        {
            var result = new Result<bool>();

            if (request.DocumentNumber == 0)
            {
                result.AddErrors(ResourceMessagesValidation.InsertOrUpdateAddressCommandValidation_RequestInvalid_Document, ErrorType.InvalidParameters);
                return result;
            }

            if(request.Address == null)
            {
                result.AddErrors(ResourceMessagesValidation.InsertOrUpdateAddressCommandValidation_RequestInvalid, ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}

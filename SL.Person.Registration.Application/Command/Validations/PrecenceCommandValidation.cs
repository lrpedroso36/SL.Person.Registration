using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class PrecenceCommandValidation
    {
        public static Result<bool> RequestValidate(this PrecenceCommand request)
        {
            var result = new Result<bool>();

            if (request.Interviewed == 0 || request.TaskMaster == 0)
            {
                result.AddErrors(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}

using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class PrecenceCommandValidation
    {
        public static ResultBase RequestValidate(this PrecenceCommand request)
        {
            var result = new Result();

            if (request.InterviewedDocument == 0 || request.LaborerDocument == 0)
            {
                result.AddErrors(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}

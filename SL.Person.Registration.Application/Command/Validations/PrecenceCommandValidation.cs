using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class PrecenceCommandValidation
    {
        public static void RequestValidate(this PrecenceCommand request)
        {
            if (request.InterviewedDocument == 0)
            {
                var result = new Result();
                result.SetErrorType(ErrorType.InvalidParameters);
                result.AddErrors(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

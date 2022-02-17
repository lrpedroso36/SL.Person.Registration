using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class InsertInterviewCommandValidation
    {
        public static ResultBase RequestValidate(this InsertInterviewCommand request)
        {
            var result = new Result();

            if (request.Interview == null)
            {
                result.AddErrors(ResourceMessagesValidation.InsertInterviewCommandValidation_RequestInvalid, ErrorType.InvalidParameters);
                return result;
            }

            if (request.Interview.Interviewed == 0 || request.Interview.Interviewer == 0)
            {
                result.AddErrors(ResourceMessagesValidation.InsertInterviewCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}

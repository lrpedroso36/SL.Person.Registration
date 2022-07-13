using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;
using System;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class InsertInterviewCommandValidation
    {
        public static void RequestValidate(this InsertInterviewCommand request)
        {
            var result = new Result();
            result.SetErrorType(ErrorType.InvalidParameters);

            if (request.Interview == null)
            {
                result.AddErrors(ResourceMessagesValidation.InsertInterviewCommandValidation_RequestInvalid);
                throw new ApplicationRequestException(result);
            }

            if (!Guid.TryParse(request.InterviewedId, out Guid idInterviewed) || !Guid.TryParse(request.InterviewerId, out Guid id))
            {
                result.AddErrors(ResourceMessagesValidation.InsertInterviewCommandValidation_DataRequestInvalid);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Commons.Responses.Extensions;
using SL.Person.Registration.CrossCuting.Resources;
using System;

namespace SL.Person.Registration.Application.Command.InsertInterview.Extensions;

public static class InsertInterviewExtensions
{
    public static void RequestValidate(this InsertInterviewCommand request)
    {
        var result = new Response();

        if (request.Interview == null)
        {
            result.ToInvalidParameter(ResourceMessagesValidation.InsertInterviewCommandValidation_RequestInvalid);
            throw new ApplicationRequestException(result);
        }

        if (!Guid.TryParse(request.InterviewedId, out _) || !Guid.TryParse(request.InterviewerId, out _))
        {
            result.ToInvalidParameter(ResourceMessagesValidation.InsertInterviewCommandValidation_DataRequestInvalid);
            throw new ApplicationRequestException(result);
        }
    }
}

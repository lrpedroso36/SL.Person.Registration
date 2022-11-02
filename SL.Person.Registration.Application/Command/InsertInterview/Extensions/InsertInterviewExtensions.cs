using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Commons.Responses.Extensions;
using System;

namespace SL.Person.Registration.Application.Command.InsertInterview.Extensions;

public static class InsertInterviewExtensions
{
    public static void RequestValidate(this InsertInterviewCommand request)
    {
        var result = new Response();

        if (request.Interview == null)
        {
            result.ToInvalidParameter("Informe os dados da entrevista.");
            throw new ApplicationRequestException(result);
        }

        if (!Guid.TryParse(request.InterviewedId, out _) || !Guid.TryParse(request.InterviewerId, out _))
        {
            result.ToInvalidParameter("Informe o código da pessoa entrevistada.");
            throw new ApplicationRequestException(result);
        }
    }
}

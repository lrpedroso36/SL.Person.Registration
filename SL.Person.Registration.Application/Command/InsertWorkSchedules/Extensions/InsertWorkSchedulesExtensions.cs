using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Commons.Responses.Extensions;
using System;

namespace SL.Person.Registration.Application.Command.InsertWorkSchedules.Extensions;

public static class InsertWorkSchedulesExtensions
{
    public static void RequestValidate(this InsertWorkSchedulesCommand request)
    {
        if (!Guid.TryParse(request.Id, out _) || request.Works.Count == 0)
        {
            var result = new Response();
            result.ToInvalidParameter("Informe o código da pessoa.");
            throw new ApplicationRequestException(result);
        }
    }
}

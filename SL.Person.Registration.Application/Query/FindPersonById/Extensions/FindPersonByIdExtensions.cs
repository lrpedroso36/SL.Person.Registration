using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Query.FindPeople.Responses;
using SL.Person.Registration.CrossCuting.Resources;
using System;

namespace SL.Person.Registration.Application.Query.FindPersonById.Extensions;

public static class FindPersonByIdExtensions
{
    public static void RequestValidate(this FindPersonByIdQuery request)
    {
        if (!Guid.TryParse(request.Id, out _))
        {
            var result = new ResponseEntities<FindPersonResponse>();
            result.ToInvalidParameter(ResourceMessagesValidation.FindPersonByIdValidation_RequestInvalid);
            throw new ApplicationRequestException(result);
        }
    }
}

using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Commons.Responses.Extensions;
using SL.Person.Registration.CrossCuting.Resources;
using System;

namespace SL.Person.Registration.Application.Command.Precence.Extensions;

public static class PrecenceExtensions
{
    public static void RequestValidate(this PrecenceCommand request)
    {
        if (!Guid.TryParse(request.Id, out _))
        {
            var result = new Response();
            result.ToInvalidParameter(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid);
            throw new ApplicationRequestException(result);
        }
    }
}

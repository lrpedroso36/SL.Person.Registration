using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Extensions;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.CrossCuting.Resources;
using SL.Person.Registration.Domain.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Application.Command.PresenceAssignment.Extensions;

public static class PresenceAssignmentExtensions
{
    public static void RequestValidate(this PresenceAssignmentCommand request)
    {
        if (!Guid.TryParse(request.Id, out _))
        {
            var result = new Result();
            result.ToInvalidParameter(ResourceMessagesValidation.PresenceAssignmentCommandValidation_RequestInvalid_Id);
            throw new ApplicationRequestException(result);
        }
    }

    public static void RequestValidateDateAssingment(this DateTime datePresence, IEnumerable<Assignment> assignments)
    {
        if (assignments != null && assignments.Any(x => x.Date.Date == datePresence.Date))
        {
            var result = new Result();
            result.ToInvalidParameter(ResourceMessagesValidation.PresenceAssignmentCommandValidation_RequestInvalid_Presence);
            throw new ApplicationRequestException(result);
        }
    }
}

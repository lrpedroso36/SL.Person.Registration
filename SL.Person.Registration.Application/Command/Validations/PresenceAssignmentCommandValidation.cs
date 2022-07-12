using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;
using SL.Person.Registration.Domain.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class PresenceAssignmentCommandValidation
    {
        public static void RequestValidate(this PresenceAssignmentCommand request)
        {
            if (request.LaborerDocument == 0)
            {
                var result = new Result();
                result.SetErrorType(ErrorType.InvalidParameters);
                result.AddErrors(ResourceMessagesValidation.PresenceAssignmentCommandValidation_RequestInvalid_Document);
                throw new ApplicationRequestException(result);
            }
        }

        public static void RequestValidateDateAssingment(this DateTime datePresence, IEnumerable<Assignment> assignments)
        {
            if (assignments != null && assignments.Any(x => x.Date.Date == datePresence.Date))
            {
                var result = new Result();
                result.SetErrorType(ErrorType.InvalidParameters);
                result.AddErrors(ResourceMessagesValidation.PresenceAssignmentCommandValidation_RequestInvalid_Presence);
                throw new ApplicationRequestException(result);
            }
        }
    }
}

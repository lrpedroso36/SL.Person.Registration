﻿using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Query.Validations
{
    public static class FindPersonByContactNumberQueryValidation
    {
        public static ResultBase RequestValidate(this FindPersonByContactNumberQuery request)
        {
            var result = new ResultEntities<FindPersonResult>();

            if (request.Ddd == 0 || request.PhoneNumber == 0)
            {
                result.AddErrors(ResourceMessagesValidation.FindPersonByContactNumberQueryValidation_RequestInvalid, ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}

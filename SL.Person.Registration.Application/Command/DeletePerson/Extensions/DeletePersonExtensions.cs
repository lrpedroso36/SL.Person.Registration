using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Commons.Responses.Enums;
using SL.Person.Registration.CrossCuting.Resources;
using System;

namespace SL.Person.Registration.Application.Command.DeletePerson.Extensions;

public static class DeletePersonExtensions
{
    public static DeletePersonCommand RequestValidate(this DeletePersonCommand command)
    {
        if (!Guid.TryParse(command.Id, out _))
        {
            var result = new Result();
            result.SetErrorType(ErrorType.InvalidParameters);
            result.AddErrors(ResourceMessagesValidation.DeletePersonCommandValidation_RequestInvalid);
            throw new ApplicationRequestException(result);
        }

        return command;
    }
}

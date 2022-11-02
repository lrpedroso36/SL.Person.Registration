using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Commons.Responses.Extensions;
using System;

namespace SL.Person.Registration.Application.Command.DeletePerson.Extensions;

public static class DeletePersonExtensions
{
    public static DeletePersonCommand RequestValidate(this DeletePersonCommand command)
    {
        if (!Guid.TryParse(command.Id, out _))
        {
            var result = new Response();
            result.ToInvalidParameter("Informe o código da pessoa.");
            throw new ApplicationRequestException(result);
        }

        return command;
    }
}
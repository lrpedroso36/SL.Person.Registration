using MediatR;
using SL.Person.Registration.Application.Commons.Requests;

namespace SL.Person.Registration.Application.Command.Person.Update;

public class UpdatePersonCommand : IRequest
{
    public UpdatePersonCommand(PersonRequest person)
    {
        Person = person;
    }

    public PersonRequest Person { get; }
}

using MediatR;
using SL.Person.Registration.Application.Requests;

namespace SL.Person.Registration.Application.Command.UpdatePerson;

public class UpdatePersonCommand : IRequest
{
    public UpdatePersonCommand(PersonRequest person)
    {
        Person = person;
    }

    public PersonRequest Person { get; }
}

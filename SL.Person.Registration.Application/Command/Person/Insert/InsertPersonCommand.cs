using MediatR;
using SL.Person.Registration.Application.Commons.Requests;

namespace SL.Person.Registration.Application.Command.Person.Insert;

public class InsertPersonCommand : IRequest
{
    public InsertPersonCommand(PersonRequest person)
    {
        Person = person;
    }

    public PersonRequest Person { get; }
}

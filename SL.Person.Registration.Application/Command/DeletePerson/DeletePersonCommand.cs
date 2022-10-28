using MediatR;

namespace SL.Person.Registration.Application.Command.DeletePerson;

public class DeletePersonCommand : IRequest
{
    public string Id { get; private set; }

    public DeletePersonCommand(string id)
    {
        Id = id;
    }
}

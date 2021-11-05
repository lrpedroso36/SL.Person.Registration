using MediatR;
using SL.Person.Registration.Domain.Requests;

namespace SL.Person.Registration.Application.Command
{
    public class UpdatePersonCommand : IRequest<bool>
    {
        public UpdatePersonCommand(PersonRequest person)
        {
            Person = person;
        }

        public PersonRequest Person { get; }
    }
}

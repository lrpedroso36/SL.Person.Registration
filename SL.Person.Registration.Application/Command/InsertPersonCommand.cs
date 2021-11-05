using MediatR;
using SL.Person.Registration.Domain.Requests;

namespace SL.Person.Registration.Application.Command
{
    public class InsertPersonCommand : IRequest<bool>
    {
        public InsertPersonCommand(PersonRequest person)
        {
            Person = person;
        }

        public PersonRequest Person { get; }
    }
}

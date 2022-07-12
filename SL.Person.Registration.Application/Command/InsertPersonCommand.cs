using MediatR;
using SL.Person.Registration.Application.Requests;

namespace SL.Person.Registration.Application.Command
{
    public class InsertPersonCommand : IRequest
    {
        public InsertPersonCommand(PersonRequest person)
        {
            Person = person;
        }

        public PersonRequest Person { get; }
    }
}

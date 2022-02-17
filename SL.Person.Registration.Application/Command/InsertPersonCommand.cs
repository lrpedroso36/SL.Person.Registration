using MediatR;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results;

namespace SL.Person.Registration.Application.Command
{
    public class InsertPersonCommand : IRequest<ResultBase>
    {
        public InsertPersonCommand(PersonRequest person)
        {
            Person = person;
        }

        public PersonRequest Person { get; }
    }
}

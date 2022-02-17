using MediatR;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results;

namespace SL.Person.Registration.Application.Command
{
    public class UpdatePersonCommand : IRequest<ResultBase>
    {
        public UpdatePersonCommand(PersonRequest person)
        {
            Person = person;
        }

        public PersonRequest Person { get; }
    }
}

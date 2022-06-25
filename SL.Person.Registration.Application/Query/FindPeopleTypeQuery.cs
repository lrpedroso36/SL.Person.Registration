using MediatR;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Results;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query
{
    public class FindPeopleTypeQuery : IRequest<ResultEntities<IEnumerable<FindPersonResult>>>
    {
        public PersonType Type { get; private set; }

        public FindPeopleTypeQuery(PersonType type)
        {
            Type = type;
        }
    }
}

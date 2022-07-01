using MediatR;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Results;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query
{
    public class FindPeopleQuery : IRequest<ResultEntities<IEnumerable<FindPersonResult>>>
    {
        public string Parameter { get; private set; }

        public PersonType? PersonType { get; private set; }

        public FindPeopleQuery(string parameter, PersonType? personType)
        {
            Parameter = parameter;
            PersonType = personType;
        }
    }
}

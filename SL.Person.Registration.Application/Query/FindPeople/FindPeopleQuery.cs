using MediatR;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query.FindPeople;

public class FindPeopleQuery : IRequest<ResultEntities<IEnumerable<FindPeopleResult>>>
{
    public string Name { get; private set; }

    public long DocumentNumber { get; private set; }

    public PersonType? PersonType { get; private set; }

    public FindPeopleQuery(string name, long documentNumber, PersonType? personType)
    {
        Name = name;
        DocumentNumber = documentNumber;
        PersonType = personType;
    }
}

using MediatR;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Query.FindPersonById.Responses;
using System;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query.FindPeople;

public record FindPeopleQuery : IRequest<ResponseEntities<IEnumerable<FindPeopleResponse>>>
{
    public string Name { get; private set; }

    public long DocumentNumber { get; private set; }

    public Guid? PersonTypeId { get; private set; }

    public FindPeopleQuery(string name, long documentNumber, Guid? personTypeId)
    {
        Name = name;
        DocumentNumber = documentNumber;
        PersonTypeId = personTypeId;
    }
}

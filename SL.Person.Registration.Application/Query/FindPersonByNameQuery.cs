using MediatR;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Contrats;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query
{
    public class FindPersonByNameQuery : IRequest<IResult<IEnumerable<FindPersonResult>>>
    {
        public string Name { get; private set; }

        public FindPersonByNameQuery(string name)
        {
            Name = name;
        }
    }
}

using MediatR;
using SL.Person.Registration.Domain.Results;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query
{
    public class FindPersonByNameQuery : IRequest<ResultEntities<IEnumerable<FindPersonResult>>>
    {
        public string Name { get; private set; }

        public FindPersonByNameQuery(string name)
        {
            Name = name;
        }
    }
}

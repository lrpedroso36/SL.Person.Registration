using MediatR;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPersonByNameQueryHandler : IRequestHandler<FindPersonByNameQuery, IEnumerable<FindPersonResult>>
    {
        private IPersonRepository _personRepository;

        public FindPersonByNameQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<FindPersonResult>> Handle(FindPersonByNameQuery request, CancellationToken cancellationToken)
        {
            var result = new List<FindPersonResult>();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return result;
            }

            var personRegistration = _personRepository.GetByName(request.Name);

            if (personRegistration == null)
            {
                return result;
            }

            foreach (var item in personRegistration)
            {
                result.Add((FindPersonResult)item);
            }

            return result;
        }
    }
}

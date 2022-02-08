using MediatR;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPersonByContactNumberQueryHandler : IRequestHandler<FindPersonByContactNumberQuery, FindPersonResult>
    {
        private IPersonRepository _personRepository;

        public FindPersonByContactNumberQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<FindPersonResult> Handle(FindPersonByContactNumberQuery request, CancellationToken cancellationToken)
        {
            var result = new FindPersonResult();

            if (request.Ddd == 0 || request.PhoneNumber == 0)
            {
                return result;
            }

            var personRegistration = _personRepository.GetByContactNumber(request.Ddd, request.PhoneNumber);

            if (personRegistration == null)
            {
                return result;
            }

            result = (FindPersonResult)personRegistration;

            return result;
        }
    }
}

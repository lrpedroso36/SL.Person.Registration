using MediatR;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Base;
using SL.Person.Registration.Domain.Results.Contrats;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPersonByContactNumberQueryHandler : IRequestHandler<FindPersonByContactNumberQuery, IResult<FindPersonResult>>
    {
        private readonly IPersonRegistrationRepository _personRepository;

        public FindPersonByContactNumberQueryHandler(IPersonRegistrationRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IResult<FindPersonResult>> Handle(FindPersonByContactNumberQuery request, CancellationToken cancellationToken)
        {
            var result = new Result<FindPersonResult>();

            if (request.Ddd == 0 || request.PhoneNumber == 0)
            {
                result.AddErrors("Informe o número do DDD e Celular.");
                return result;
            }

            var personRegistration = _personRepository.GetByContactNumber(request.Ddd, request.PhoneNumber);

            if (personRegistration == null)
            {
                result.AddErrors("Pessoa não encontrada.");
                return result;
            }

            result.SetData((FindPersonResult)personRegistration);

            return result;
        }
    }
}

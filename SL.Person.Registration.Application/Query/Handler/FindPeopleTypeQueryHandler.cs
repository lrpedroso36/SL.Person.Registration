using MediatR;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPeopleTypeQueryHandler : IRequestHandler<FindPeopleTypeQuery, ResultEntities<IEnumerable<FindPersonResult>>>
    {
        private IPersonRegistrationRepository _repository;

        public FindPeopleTypeQueryHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultEntities<IEnumerable<FindPersonResult>>> Handle(FindPeopleTypeQuery request, CancellationToken cancellationToken)
        {
            request.RequestValidate();

            var result = new ResultEntities<IEnumerable<FindPersonResult>>();

            var personRegistration = _repository.GetByType(request.Type);

            personRegistration.ValidateList();

            result.SetData(personRegistration.Select(x => (FindPersonResult)x).ToList());
            return result;
        }
    }
}

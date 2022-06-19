using MediatR;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPeopleQueryHandler : IRequestHandler<FindPeopleQuery, ResultEntities<IEnumerable<FindPersonResult>>>
    {
        private readonly IPersonRegistrationRepository _repository;

        public FindPeopleQueryHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultEntities<IEnumerable<FindPersonResult>>> Handle(FindPeopleQuery request, CancellationToken cancellationToken)
        {
            request.RequestValidate();

            var result = new ResultEntities<IEnumerable<FindPersonResult>>();

            if (long.TryParse(request.Parameter, out long documentNumber))
            {
                var personRegistrationDocument = _repository.GetByDocument(documentNumber);
                 
                personRegistrationDocument.ValidateInstance();

                result.SetData(new List<FindPersonResult>() { (FindPersonResult)personRegistrationDocument });
                return result;
            }

            var personRegistration = _repository.GetByName(request.Parameter);

            personRegistration.ValidateList();

            result.SetData(personRegistration.Select(x => (FindPersonResult)x).ToList());
            return result;
        }
    }
}

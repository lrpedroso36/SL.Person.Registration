using MediatR;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
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

            if (long.TryParse(request.Parameter, out long documentNumber))
            {
                if (request.PersonType.HasValue)
                {
                    return FindPeopleByDocumentAndType(documentNumber, request.PersonType.Value);
                }

                return FindPeopleByDocument(documentNumber);
            }

            if (request.PersonType.HasValue)
            {
                return FindPeopleByNameAndType(request.Parameter, request.PersonType.Value);
            }

            return FindPeopleByName(request.Parameter);
        }
        private ResultEntities<IEnumerable<FindPersonResult>> FindPeopleByNameAndType(string name, PersonType type)
        {
            var result = new ResultEntities<IEnumerable<FindPersonResult>>();

            var personRegistration = _repository.GetByName(name, type);

            personRegistration.ValidateList();

            result.SetData(personRegistration.Select(x => (FindPersonResult)x).ToList());
            return result;
        }

        private ResultEntities<IEnumerable<FindPersonResult>> FindPeopleByName(string name)
        {
            var result = new ResultEntities<IEnumerable<FindPersonResult>>();

            var personRegistration = _repository.GetByName(name);

            personRegistration.ValidateList();

            result.SetData(personRegistration.Select(x => (FindPersonResult)x).ToList());
            return result;
        }

        private ResultEntities<IEnumerable<FindPersonResult>> FindPeopleByDocumentAndType(long documentNumber, PersonType type)
        {
            var result = new ResultEntities<IEnumerable<FindPersonResult>>();

            var personRegistrationDocument = _repository.GetByDocument(documentNumber, type);

            personRegistrationDocument.ValidateInstance();

            result.SetData(new List<FindPersonResult>() { (FindPersonResult)personRegistrationDocument });

            return result;
        }

        private ResultEntities<IEnumerable<FindPersonResult>> FindPeopleByDocument(long documentNumber)
        {
            var result = new ResultEntities<IEnumerable<FindPersonResult>>();

            var personRegistrationDocument = _repository.GetByDocument(documentNumber);

            personRegistrationDocument.ValidateInstance();

            result.SetData(new List<FindPersonResult>() { (FindPersonResult)personRegistrationDocument });

            return result;
        }
    }
}

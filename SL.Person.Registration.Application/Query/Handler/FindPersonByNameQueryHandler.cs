using MediatR;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPersonByNameQueryHandler : IRequestHandler<FindPersonByNameQuery, ResultEntities<IEnumerable<FindPersonResult>>>
    {
        private readonly IPersonRegistrationRepository _repository;

        public FindPersonByNameQueryHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultEntities<IEnumerable<FindPersonResult>>> Handle(FindPersonByNameQuery request, CancellationToken cancellationToken)
        {
            request.RequestValidate();

            var personRegistration = _repository.GetByName(request.Name);

            var result = new ResultEntities<IEnumerable<FindPersonResult>>();

            if (personRegistration == null || !personRegistration.Any())
            {
                result.SetErrorType(ErrorType.NotFoundData);
                result.AddErrors(ResourceMessagesValidation.FindPersonByNameQueryValidation_NotFound);
                return result;
            }

            result.SetData(personRegistration.Select(x => (FindPersonResult)x).ToList());
            return result;
        }
    }
}

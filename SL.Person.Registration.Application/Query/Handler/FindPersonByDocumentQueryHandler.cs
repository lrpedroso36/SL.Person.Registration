using MediatR;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Base;
using SL.Person.Registration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;


namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPersonByDocumentQueryHandler : IRequestHandler<FindPersonByDocumentQuery, ResultBase>
    {
        private readonly IPersonRegistrationRepository _repository;

        public FindPersonByDocumentQueryHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultBase> Handle(FindPersonByDocumentQuery request, CancellationToken cancellationToken)
        {
            request.RequestValidate();

            var personRegistration = _repository.GetByDocument(request.DocumentNumber);

            personRegistration.ValidateInstance();

            var resultFindPerson = new ResultEntities<FindPersonResult>();

            resultFindPerson.SetData((FindPersonResult)personRegistration);

            return resultFindPerson;
        }
    }
}

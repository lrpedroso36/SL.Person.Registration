using MediatR;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Base;
using System.Threading;
using System.Threading.Tasks;


namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPersonByContactNumberQueryHandler : IRequestHandler<FindPersonByContactNumberQuery, ResultBase>
    {
        private readonly IPersonRegistrationRepository _repository;

        public FindPersonByContactNumberQueryHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultBase> Handle(FindPersonByContactNumberQuery request, CancellationToken cancellationToken)
        {
            request.RequestValidate();

            var personRegistration = _repository.GetByContactNumber(request.Ddd, request.PhoneNumber);

            personRegistration.ValidateInstance();

            var resultFindPerson = new ResultEntities<FindPersonResult>();

            resultFindPerson.SetData((FindPersonResult)personRegistration);

            return resultFindPerson;
        }
    }
}

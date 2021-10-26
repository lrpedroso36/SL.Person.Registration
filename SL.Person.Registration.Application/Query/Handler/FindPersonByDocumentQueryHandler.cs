using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPersonByDocumentQueryHandler : IRequestHandler<FindPersonByDocumentQuery, FindPersonResult>
    {
        private IInformationRegistrationRepository _repository;

        public FindPersonByDocumentQueryHandler(IInformationRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<FindPersonResult> Handle(FindPersonByDocumentQuery request, CancellationToken cancellationToken)
        {
            var informationRegistration =  _repository.GetByDocument(request.DocumentNumber);

            var result = new FindPersonResult();

            if(informationRegistration == null && informationRegistration.PersonRegistration == null)
            {
                return result;
            }

            result = (FindPersonResult)informationRegistration.PersonRegistration;

            return result;
        }
    }
}

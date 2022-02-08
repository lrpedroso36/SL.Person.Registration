using MediatR;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPersonByDocumentQueryHandler : IRequestHandler<FindPersonByDocumentQuery, FindPersonResult>
    {
        private readonly IPersonRepository _repository;

        public FindPersonByDocumentQueryHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<FindPersonResult> Handle(FindPersonByDocumentQuery request, CancellationToken cancellationToken)
        {
            var result = new FindPersonResult();

            if (request.DocumentNumber == 0)
            {
                return result;
            }

            var personRegistration = _repository.GetByDocument(request.DocumentNumber);

            if (personRegistration == null)
            {
                return result;
            }

            result = (FindPersonResult)personRegistration;

            return result;
        }
    }
}

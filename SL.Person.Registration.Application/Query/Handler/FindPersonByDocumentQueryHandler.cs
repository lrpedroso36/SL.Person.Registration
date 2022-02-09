using MediatR;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Base;
using SL.Person.Registration.Domain.Results.Contrats;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPersonByDocumentQueryHandler : IRequestHandler<FindPersonByDocumentQuery, IResult<FindPersonResult>>
    {
        private readonly IPersonRegistrationRepository _repository;

        public FindPersonByDocumentQueryHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResult<FindPersonResult>> Handle(FindPersonByDocumentQuery request, CancellationToken cancellationToken)
        {
            var result = new Result<FindPersonResult>();

            if (request.DocumentNumber == 0)
            {
                result.AddErrors("Informe o número do Documento.");
                return result;
            }

            var personRegistration = _repository.GetByDocument(request.DocumentNumber);

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

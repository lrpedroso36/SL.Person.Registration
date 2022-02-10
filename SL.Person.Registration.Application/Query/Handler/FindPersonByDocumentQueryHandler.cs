using MediatR;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Contrats;
using SL.Person.Registration.Domain.Results.Enums;
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
            var result = request.RequestValidate();

            if (!result.IsSuccess)
            {
                return result;
            }

            var personRegistration = _repository.GetByDocument(request.DocumentNumber);

            if (personRegistration == null)
            {
                result.AddErrors("Pessoa não encontrada.", ErrorType.NotFoundData);
                return result;
            }

            result.SetData((FindPersonResult)personRegistration);

            return result;
        }
    }
}

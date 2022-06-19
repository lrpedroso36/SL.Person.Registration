using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IPersonRegistrationRepository _repository;

        public DeletePersonCommandHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            request.RequestValidate();

            var personRegistration = _repository.GetByDocument(request.DocumentNumber);

            personRegistration.ValidateInstance();

            _repository.Delete(request.DocumentNumber);

            return Unit.Value;
        }
    }
}

using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class AddressCommandHandler : IRequestHandler<AddressCommand>
    {
        private readonly IPersonRegistrationRepository _repository;

        public AddressCommandHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddressCommand request, CancellationToken cancellationToken)
        {
            request.RequestValidate();

            var personRegistration = _repository.GetByDocument(request.DocumentNumber);

            personRegistration.ValidateInstance();

            var address = request.Address.GetAddress();

            address.Validate();

            personRegistration.AddAdress(address);

            _repository.Update(personRegistration);

            return Unit.Value;
        }
    }
}

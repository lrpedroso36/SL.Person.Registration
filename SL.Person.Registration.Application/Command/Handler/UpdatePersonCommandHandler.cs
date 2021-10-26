using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SL.Person.Registration.Domain.RegistrationAggregate;
using SL.Person.Registration.Domain.Repositories;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private IInformationRegistrationRepository _repository;

        public UpdatePersonCommandHandler(IInformationRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var informationRegistration = _repository.GetByDocument(request.DocumentNumber);

            var person = request.GetPersonRegistration();

            var update = InformationRegistration.CreateInstance(person, null, informationRegistration._id);

            _repository.Update(update);

            return true;
        }
    }
}

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
            if (request.Person == null || request.Person.DocumentNumber == 0)
            {
                return false;
            }

            var informationRegistration = _repository.GetByDocument(request.Person.DocumentNumber);

            if(informationRegistration == null || informationRegistration.PersonRegistration == null)
            {
                return false;
            }

            var person = request.Person.GetPersonRegistration();

            var update = InformationRegistration.CreateInstance(person, null, informationRegistration._id);

            _repository.Update(update);

            return true;
        }
    }
}

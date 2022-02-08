using MediatR;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private IPersonRepository _repository;

        public UpdatePersonCommandHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            if (request.Person == null || request.Person.DocumentNumber == 0)
            {
                return false;
            }

            var personRegistration = _repository.GetByDocument(request.Person.DocumentNumber);

            if (personRegistration == null)
            {
                return false;
            }

            var person = request.Person.GetPersonRegistration();

            var update = PersonRegistration.CreateInstance(person.Types, person.Name, person.Gender,
                person.YearsOld, person.DocumentNumber, person.Address, person.Contact);

            update.SetId(personRegistration._id);

            _repository.Update(update);

            return true;
        }
    }
}

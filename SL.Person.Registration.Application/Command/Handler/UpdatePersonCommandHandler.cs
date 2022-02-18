using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IPersonRegistrationRepository _repository;

        public UpdatePersonCommandHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            request.RequestValidate();

            var personRegistration = _repository.GetByDocument(request.Person.DocumentNumber);

            personRegistration.ValidateInstance();

            var person = request.Person.GetPersonRegistration();

            person.Validate();

            var update = PersonRegistration.CreateUpdateInstance(personRegistration._id, person.Types, person.Name, person.Gender,
                person.YearsOld, person.DocumentNumber);

            _repository.Update(update);

            return Unit.Value;
        }
    }
}

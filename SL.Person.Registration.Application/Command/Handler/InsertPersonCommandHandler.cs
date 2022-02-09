using MediatR;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Hanler
{
    public class InsertPersonCommandHandler : IRequestHandler<InsertPersonCommand, bool>
    {
        private readonly IPersonRegistrationRepository _repository;

        public InsertPersonCommandHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            if (request.Person == null || request.Person.DocumentNumber == 0)
            {
                return false;
            }

            var person = request.Person.GetPersonRegistration();

            var registration = PersonRegistration.CreateInstance(person.Types, person.Name, person.Gender,
                           person.YearsOld, person.DocumentNumber, person.Address, person.Contact);

            _repository.Insert(registration);

            return true;
        }
    }
}

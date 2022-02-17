using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Extensions;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Hanler
{
    public class InsertPersonCommandHandler : IRequestHandler<InsertPersonCommand, ResultBase>
    {
        private readonly IPersonRegistrationRepository _repository;

        public InsertPersonCommandHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultBase> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            var result = request.RequestValidate();

            if (!result.IsSuccess)
            {
                return result;
            }

            var person = request.Person.GetPersonRegistration();

            result = person.Validate();

            if (!result.IsSuccess)
            {
                return result;
            }

            var registration = PersonRegistration.CreateInstance(person.Types, person.Name, person.Gender,
                           person.YearsOld, person.DocumentNumber);

            _repository.Insert(registration);

            return result;
        }
    }
}

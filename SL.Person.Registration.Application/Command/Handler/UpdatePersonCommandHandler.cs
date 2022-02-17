using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Extensions;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, ResultBase>
    {
        private IPersonRegistrationRepository _repository;

        public UpdatePersonCommandHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultBase> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var result = request.RequestValidate();

            if (!result.IsSuccess)
            {
                return result;
            }

            var personRegistration = _repository.GetByDocument(request.Person.DocumentNumber);

            result = personRegistration.ValidateInstance();

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

            var update = PersonRegistration.CreateInstance(person.Types, person.Name, person.Gender,
                person.YearsOld, person.DocumentNumber);

            _repository.Update(update);

            return result;
        }
    }
}

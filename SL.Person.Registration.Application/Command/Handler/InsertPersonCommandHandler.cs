using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results.Contrats;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Hanler
{
    public class InsertPersonCommandHandler : IRequestHandler<InsertPersonCommand, IResult<bool>>
    {
        private readonly IPersonRegistrationRepository _repository;

        public InsertPersonCommandHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResult<bool>> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            var result = request.RequestValidate();

            if (!result.IsSuccess)
            {
                return result;
            }

            var person = request.Person.GetPersonRegistration();

            var registration = PersonRegistration.CreateInstance(person.Types, person.Name, person.Gender,
                           person.YearsOld, person.DocumentNumber, person.Address, person.Contact);

            _repository.Insert(registration);

            result.SetData(true);

            return result;
        }
    }
}

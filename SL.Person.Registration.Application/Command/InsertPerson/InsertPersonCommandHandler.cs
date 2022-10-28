using MediatR;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.InsertPerson;

public class InsertPersonCommandHandler : IRequestHandler<InsertPersonCommand>
{
    private readonly IPersonRegistrationRepository _repository;

    public InsertPersonCommandHandler(IPersonRegistrationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
    {
        request.RequestValidate();

        var personResult = _repository.GetByDocument(request.Person.DocumentNumber);

        personResult.ValidateFoundInstance();

        var person = request.Person.GetPersonRegistration();

        person.Validate();

        var registration = PersonRegistration.CreateInstance(person.Types, person.Name, person.Gender, person.BithDate, person.DocumentNumber);
        registration.AddContact(person.Contact);
        registration.AddAdress(person.Address);

        _repository.Insert(registration);

        return Unit.Value;
    }
}

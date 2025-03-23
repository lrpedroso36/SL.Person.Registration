using MediatR;
using SL.Person.Registration.Application.Command.Person.Extensions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Person.Insert;

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

        var personResult = await _repository.GetByDocumentASync(request.Person.DocumentNumber, cancellationToken);

        personResult.ValidateFoundInstance();

        var person = request.Person.GetPersonRegistration();

        person.Validate();

        var registration = PersonRegistration.CreateInstance([.. person.PersonRegistrationPersonTypes.Select(x => x.PersonType)], person.Name, person.Gender, person.BithDate, person.DocumentNumber);
        registration.AddContact(person.Contact);
        registration.AddAdress(person.Address);

        await _repository.InsertAsync(registration, cancellationToken);

        return Unit.Value;
    }
}

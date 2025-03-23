using MediatR;
using SL.Person.Registration.Application.Command.Person.Extensions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Person.Update;

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

        var personRegistration = await _repository.GetByDocumentASync(request.Person.DocumentNumber, cancellationToken);

        personRegistration.ValidateIsNotFoundInstance();

        var person = request.Person.GetPersonRegistration();

        person.Validate();

        var update = PersonRegistration.CreateUpdateInstance(personRegistration.Id, [.. person.PersonRegistrationPersonTypes.Select(x => x.PersonType)], person.Name, person.Gender,
            person.BithDate, person.DocumentNumber, personRegistration.Interviews, personRegistration.Assignments, personRegistration.WorkSchedules);

        update.AddAdress(person.Address);
        update.AddContact(person.Contact);

        await _repository.UpdateAsync(update, cancellationToken);

        return Unit.Value;
    }
}

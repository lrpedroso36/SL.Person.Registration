using MediatR;
using SL.Person.Registration.Application.Command.Person.Extensions;
using SL.Person.Registration.Application.Command.PresenceAssignment.Extensions;
using SL.Person.Registration.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.PresenceAssignment;

public class PresenceAssignmentCommandHandler : IRequestHandler<PresenceAssignmentCommand>
{
    private readonly IPersonRegistrationRepository _repository;

    public PresenceAssignmentCommandHandler(IPersonRegistrationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(PresenceAssignmentCommand request, CancellationToken cancellationToken)
    {
        request.RequestValidate();

        var personLaborer = await _repository.GetByIdAsync(request.Id, cancellationToken);

        personLaborer.ValidateIsNotFoundInstance();

        var datePresence = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);
        datePresence.RequestValidateDateAssingment(personLaborer.Assignments);

        personLaborer.SetPresenceAssignment(datePresence, true);

        await _repository.UpdateAsync(personLaborer, cancellationToken);

        return Unit.Value;
    }
}

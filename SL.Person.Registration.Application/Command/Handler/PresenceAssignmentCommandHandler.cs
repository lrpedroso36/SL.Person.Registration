using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
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

            var personLaborer = _repository.GetByDocument(request.LaborerDocument);

            personLaborer.ValidateInstance();

            var datePresence = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);
            datePresence.RequestValidateDateAssingment(personLaborer.Assignments);

            personLaborer.SetPresenceAssignment(datePresence, true);

            _repository.Update(personLaborer);

            return Unit.Value;
        }
    }
}

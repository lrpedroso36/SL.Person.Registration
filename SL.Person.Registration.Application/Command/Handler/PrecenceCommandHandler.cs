using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class PrecenceCommandHandler : IRequestHandler<PrecenceCommand>
    {
        private readonly IPersonRegistrationRepository _personRegistrationRepository;

        public PrecenceCommandHandler(IPersonRegistrationRepository personRegistrationRepository)
        {
            _personRegistrationRepository = personRegistrationRepository;
        }

        public async Task<Unit> Handle(PrecenceCommand request, CancellationToken cancellationToken)
        {
            request.RequestValidate();

            var personInterviewed = _personRegistrationRepository.GetByDocument(request.InterviewedDocument, PersonType.Assistido);

            personInterviewed.ValidateInstanceByType(PersonType.Assistido);

            var personLaborer = _personRegistrationRepository.GetByDocument(request.LaborerDocument);

            personLaborer.ValidateInstanceByType(PersonType.Tarefeiro);

            personInterviewed.SetPresenceTratament(DateTime.Now, personLaborer);

            _personRegistrationRepository.Update(personInterviewed);

            return Unit.Value;
        }
    }
}

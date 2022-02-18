using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class InsertInterviewCommandHandler : IRequestHandler<InsertInterviewCommand>
    {
        private readonly IPersonRegistrationRepository _personRegistrationRepository;

        public InsertInterviewCommandHandler(IPersonRegistrationRepository personRegistrationRepository)
        {
            _personRegistrationRepository = personRegistrationRepository;
        }

        public async Task<Unit> Handle(InsertInterviewCommand request, CancellationToken cancellationToken)
        {
            request.RequestValidate();

            var personInterviewed = _personRegistrationRepository.GetByDocument(request.Interview.Interviewed);

            personInterviewed.ValidateInstanceByType(PersonType.Assistido);

            var personInterviewer = _personRegistrationRepository.GetByDocument(request.Interview.Interviewer, PersonType.Entrevistador);

            personInterviewer.ValidateInstanceByType(PersonType.Entrevistador);

            personInterviewed.AddInterview(Interview.CreateInstance(request.Interview.TreatmentType, request.Interview.WeakDayType,
                request.Interview.Type, DateTime.Now, personInterviewer, request.Interview.Amount, request.Interview.Opinion));

            personInterviewed.AddPersonType(PersonType.Assistido);

            _personRegistrationRepository.Update(personInterviewed);

            return Unit.Value;
        }
    }
}

using MediatR;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class InsertInterviewCommandHandler : IRequestHandler<InsertInterviewCommand, bool>
    {
        private readonly IPersonRegistrationRepository _personRegistrationRepository;

        public InsertInterviewCommandHandler(IPersonRegistrationRepository personRegistrationRepository)
        {
            _personRegistrationRepository = personRegistrationRepository;
        }

        public async Task<bool> Handle(InsertInterviewCommand request, CancellationToken cancellationToken)
        {
            var person = _personRegistrationRepository.GetByDocument(request.Interview.DocumnetNumber);

            var personInterview = _personRegistrationRepository.GetByDocument(request.Interview.DocumentNumberInterview);

            person.AddInterview(Interview.CreateInstance(request.Interview.TreatmentType, request.Interview.WeakDayType,
                request.Interview.Type, DateTime.Now, personInterview, request.Interview.Amount, request.Interview.Opinion));

            person.SetId(person._id);

            _personRegistrationRepository.Update(person);

            return true;
        }
    }
}

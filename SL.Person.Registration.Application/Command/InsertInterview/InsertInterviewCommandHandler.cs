using MediatR;
using SL.Person.Registration.Application.Command.InsertInterview.Extensions;
using SL.Person.Registration.Application.Command.Person.Extensions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.InsertInterview;

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

        var personInterviewed = await _personRegistrationRepository.GetByIdAsync(request.InterviewedId, cancellationToken);

        var personInterviewer = await _personRegistrationRepository.GetByIdAsync(request.InterviewerId, cancellationToken);

        personInterviewer.ValidateIsNotFoundInstance();

        personInterviewed.AddInterview(Interview.CreateInstance(request.Interview.TreatmentType, request.Interview.WeakDayType,
            request.Interview.Type, DateTime.Now, personInterviewer, request.Interview.Amount, request.Interview.Opinion));

        personInterviewed.AddPersonType(PersonType.Assistido());

        await _personRegistrationRepository.UpdateAsync(personInterviewed, cancellationToken);

        return Unit.Value;
    }
}

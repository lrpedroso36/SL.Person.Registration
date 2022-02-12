﻿using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate.Extensions;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results.Contrats;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class InsertInterviewCommandHandler : IRequestHandler<InsertInterviewCommand, IResult<bool>>
    {
        private readonly IPersonRegistrationRepository _personRegistrationRepository;

        public InsertInterviewCommandHandler(IPersonRegistrationRepository personRegistrationRepository)
        {
            _personRegistrationRepository = personRegistrationRepository;
        }

        public async Task<IResult<bool>> Handle(InsertInterviewCommand request, CancellationToken cancellationToken)
        {
            var result = request.RequestValidate();

            if (!result.IsSuccess)
            {
                return result;
            }

            var personInterviewed = _personRegistrationRepository.GetByDocument(request.Interview.Interviewed);

            result = personInterviewed.ValidateInstanceByType<bool>(PersonType.Assistido);

            if (!result.IsSuccess)
            {
                return result;
            }

            var personInterviewer = _personRegistrationRepository.GetByDocument(request.Interview.Interviewer, PersonType.Entrevistador);

            result = personInterviewer.ValidateInstanceByType<bool>(PersonType.Entrevistador);

            if (!result.IsSuccess)
            {
                return result;
            }

            personInterviewed.AddInterview(Interview.CreateInstance(request.Interview.TreatmentType, request.Interview.WeakDayType,
                request.Interview.Type, DateTime.Now, personInterviewer, request.Interview.Amount, request.Interview.Opinion));

            personInterviewed.AddPersonType(PersonType.Assistido);

            personInterviewed.SetId(personInterviewed._id);

            _personRegistrationRepository.Update(personInterviewed);

            result.SetData(true);

            return result;
        }
    }
}

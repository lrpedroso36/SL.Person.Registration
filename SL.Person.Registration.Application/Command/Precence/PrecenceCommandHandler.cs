﻿using MediatR;
using SL.Person.Registration.Application.Command.Person.Extensions;
using SL.Person.Registration.Application.Command.Precence.Extensions;
using SL.Person.Registration.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Precence;

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

        var personInterviewed = _personRegistrationRepository.GetById(request.Id);

        personInterviewed.ValidateIsNotFoundInstance();

        var date = DateTime.Now;

        personInterviewed.SetPresenceTratament(date);

        _personRegistrationRepository.Update(personInterviewed);

        return Unit.Value;
    }
}

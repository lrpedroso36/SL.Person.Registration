﻿using MediatR;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Domain.PersonAggregate.Extensions;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Contrats;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPersonByContactNumberQueryHandler : IRequestHandler<FindPersonByContactNumberQuery, IResult<FindPersonResult>>
    {
        private readonly IPersonRegistrationRepository _personRepository;

        public FindPersonByContactNumberQueryHandler(IPersonRegistrationRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IResult<FindPersonResult>> Handle(FindPersonByContactNumberQuery request, CancellationToken cancellationToken)
        {
            var result = request.RequestValidate();

            if (!result.IsSuccess)
            {
                return result;
            }

            var personRegistration = _personRepository.GetByContactNumber(request.Ddd, request.PhoneNumber);

            result = personRegistration.Validate<FindPersonResult>();

            if (!result.IsSuccess)
            {
                return result;
            }

            result.SetData((FindPersonResult)personRegistration);

            return result;
        }
    }
}
﻿using MediatR;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Contrats;
using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPersonByNameQueryHandler : IRequestHandler<FindPersonByNameQuery, IResult<IEnumerable<FindPersonResult>>>
    {
        private readonly IPersonRegistrationRepository _personRepository;

        public FindPersonByNameQueryHandler(IPersonRegistrationRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IResult<IEnumerable<FindPersonResult>>> Handle(FindPersonByNameQuery request, CancellationToken cancellationToken)
        {
            var result = request.RequestValidate();

            if (!result.IsSuccess)
            {
                return result;
            }

            var personRegistration = _personRepository.GetByName(request.Name);

            if (personRegistration == null || !personRegistration.Any())
            {
                result.AddErrors("Pessoa não encontrada.", ErrorType.NotFoundData);
                return result;
            }

            result.SetData(personRegistration.Select(x => (FindPersonResult)x));
            return result;
        }
    }
}

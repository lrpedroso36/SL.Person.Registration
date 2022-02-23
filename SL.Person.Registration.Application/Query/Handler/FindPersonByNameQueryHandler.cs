﻿using MediatR;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindPersonByNameQueryHandler : IRequestHandler<FindPersonByNameQuery, ResultEntities<IEnumerable<FindPersonResult>>>
    {
        private readonly IPersonRegistrationRepository _repository;

        public FindPersonByNameQueryHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultEntities<IEnumerable<FindPersonResult>>> Handle(FindPersonByNameQuery request, CancellationToken cancellationToken)
        {
            request.RequestValidate();

            var personRegistration = _repository.GetByName(request.Name);

            personRegistration.ValidateList();

            var result = new ResultEntities<IEnumerable<FindPersonResult>>();
            result.SetData(personRegistration.Select(x => (FindPersonResult)x).ToList());
            return result;
        }
    }
}

using MediatR;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.FindPeople;

public class FindPeopleQueryHandler : IRequestHandler<FindPeopleQuery, ResultEntities<IEnumerable<FindPeopleResult>>>
{
    private readonly IPersonRegistrationRepository _repository;

    public FindPeopleQueryHandler(IPersonRegistrationRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultEntities<IEnumerable<FindPeopleResult>>> Handle(FindPeopleQuery request, CancellationToken cancellationToken)
    {
        request.RequestValidate();

        var result = new ResultEntities<IEnumerable<FindPeopleResult>>();

        var personRegistration = _repository.Get(request.PersonType, request.Name, request.DocumentNumber);

        personRegistration.ValidateList();

        result.SetData(personRegistration.Select(x => (FindPeopleResult)x).ToList());
        return result;
    }
}

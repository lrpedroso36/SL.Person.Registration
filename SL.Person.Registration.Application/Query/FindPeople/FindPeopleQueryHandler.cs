using MediatR;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Query.FindPeople.Extensions;
using SL.Person.Registration.Application.Query.FindPersonById.Responses;
using SL.Person.Registration.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.FindPeople;

public class FindPeopleQueryHandler : IRequestHandler<FindPeopleQuery, ResponseEntities<IEnumerable<FindPeopleResponse>>>
{
    private readonly IPersonRegistrationRepository _repository;

    public FindPeopleQueryHandler(IPersonRegistrationRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseEntities<IEnumerable<FindPeopleResponse>>> Handle(FindPeopleQuery request, CancellationToken cancellationToken)
    {
        request.RequestValidate();

        var result = new ResponseEntities<IEnumerable<FindPeopleResponse>>();

        var personRegistration = _repository.Get(request.PersonType, request.Name, request.DocumentNumber);

        personRegistration.ValidateList();

        result.SetData(personRegistration.Select(x => (FindPeopleResponse)x).ToList());
        return result;
    }
}

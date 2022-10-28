using MediatR;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Base;
using SL.Person.Registration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;


namespace SL.Person.Registration.Application.Query.FindPersonById;

public class FindPersonByIdQueryHandler : IRequestHandler<FindPersonByIdQuery, ResultBase>
{
    private readonly IPersonRegistrationRepository _repository;

    public FindPersonByIdQueryHandler(IPersonRegistrationRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultBase> Handle(FindPersonByIdQuery request, CancellationToken cancellationToken)
    {
        request.RequestValidate();

        var personRegistration = _repository.GetById(request.Id);

        personRegistration.ValidateInstance();

        var resultFindPerson = new ResultEntities<FindPersonResult>();

        resultFindPerson.SetData((FindPersonResult)personRegistration);

        return resultFindPerson;
    }
}

using MediatR;
using SL.Person.Registration.Application.Command.Person.Extensions;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Commons.Responses.Base;
using SL.Person.Registration.Application.Query.FindPeople.Responses;
using SL.Person.Registration.Application.Query.FindPersonById.Extensions;
using SL.Person.Registration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;


namespace SL.Person.Registration.Application.Query.FindPersonById;

public class FindPersonByIdQueryHandler : IRequestHandler<FindPersonByIdQuery, ResponseBase>
{
    private readonly IPersonRegistrationRepository _repository;

    public FindPersonByIdQueryHandler(IPersonRegistrationRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseBase> Handle(FindPersonByIdQuery request, CancellationToken cancellationToken)
    {
        request.RequestValidate();

        var personRegistration = await _repository.GetByIdAsync(request.Id, cancellationToken);

        personRegistration.ValidateIsNotFoundInstance();

        var resultFindPerson = new ResponseEntities<FindPersonResponse>();

        resultFindPerson.SetData((FindPersonResponse)personRegistration);

        return resultFindPerson;
    }
}

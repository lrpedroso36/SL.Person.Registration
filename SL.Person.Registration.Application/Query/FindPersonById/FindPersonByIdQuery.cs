using MediatR;
using SL.Person.Registration.Application.Commons.Responses.Base;

namespace SL.Person.Registration.Application.Query.FindPersonById;

public class FindPersonByIdQuery : IRequest<ResponseBase>
{
    public FindPersonByIdQuery(string id)
    {
        Id = id;
    }

    public string Id { get; }
}

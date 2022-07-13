using MediatR;
using SL.Person.Registration.Application.Results.Base;

namespace SL.Person.Registration.Application.Query
{
    public class FindPersonByIdQuery : IRequest<ResultBase>
    {
        public FindPersonByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}

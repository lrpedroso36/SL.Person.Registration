using MediatR;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Contrats;

namespace SL.Person.Registration.Application.Query
{
    public class FindPersonByDocumentQuery : IRequest<IResult<FindPersonResult>>
    {
        public FindPersonByDocumentQuery(long documentNumber)
        {
            DocumentNumber = documentNumber;
        }

        public long DocumentNumber { get; }
    }
}

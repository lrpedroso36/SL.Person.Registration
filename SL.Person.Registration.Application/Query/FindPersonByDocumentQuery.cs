using MediatR;
using SL.Person.Registration.Domain.Results.Base;

namespace SL.Person.Registration.Application.Query
{
    public class FindPersonByDocumentQuery : IRequest<ResultBase>
    {
        public FindPersonByDocumentQuery(long documentNumber)
        {
            DocumentNumber = documentNumber;
        }

        public long DocumentNumber { get; }
    }
}

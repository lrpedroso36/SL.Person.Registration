using MediatR;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results;

namespace SL.Person.Registration.Application.Command
{
    public class ContactCommand : IRequest<ResultBase>
    {
        public ContactCommand(long documentNumber, ContactRequest request)
        {
            DocumentNumber = documentNumber;
            Contact = request;
        }

        public long DocumentNumber { get; }
        public ContactRequest Contact { get; }
    }
}

using MediatR;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results.Contrats;

namespace SL.Person.Registration.Application.Command
{
    public class ContactCommand : IRequest<IResult<bool>>
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

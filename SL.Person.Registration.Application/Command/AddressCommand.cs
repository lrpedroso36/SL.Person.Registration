using MediatR;
using SL.Person.Registration.Domain.Requests;

namespace SL.Person.Registration.Application.Command
{
    public class AddressCommand : IRequest
    {
        public AddressCommand(long documentNumber, AddressRequest request)
        {
            Address = request;
            DocumentNumber = documentNumber;
        }

        public AddressRequest Address { get; }
        public long DocumentNumber { get; }
    }
}

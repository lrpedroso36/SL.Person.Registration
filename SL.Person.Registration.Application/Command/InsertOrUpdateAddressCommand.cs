using MediatR;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results.Contrats;

namespace SL.Person.Registration.Application.Command
{
    public class InsertOrUpdateAddressCommand : IRequest<IResult<bool>>
    {
        public InsertOrUpdateAddressCommand(long documentNumber, AddressRequest request)
        {
            Address = request;
            DocumentNumber = documentNumber;
        }

        public AddressRequest Address { get; }
        public long DocumentNumber { get; }
    }
}

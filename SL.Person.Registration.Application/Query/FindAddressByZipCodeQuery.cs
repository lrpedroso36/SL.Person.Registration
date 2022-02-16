using MediatR;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Results.Contrats;

namespace SL.Person.Registration.Application.Query
{
    public class FindAddressByZipCodeQuery : IRequest<IResult<Address>>
    {
        public string ZipCode { get; }

        public FindAddressByZipCodeQuery(string zipCode)
        {
            ZipCode = zipCode;
        }
    }
}

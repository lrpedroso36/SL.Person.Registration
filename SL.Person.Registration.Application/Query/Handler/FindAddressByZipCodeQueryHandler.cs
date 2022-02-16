using MediatR;
using SL.Person.Registration.Domain.External.Contracts;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Contrats;
using SL.Person.Registration.Domain.Results.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindAddressByZipCodeQueryHandler : IRequestHandler<FindAddressByZipCodeQuery, IResult<Address>>
    {
        private readonly IAddressApi _addressApi;

        public FindAddressByZipCodeQueryHandler(IAddressApi addressApi)
        {
            _addressApi = addressApi;
        }

        public async Task<IResult<Address>> Handle(FindAddressByZipCodeQuery request, CancellationToken cancellationToken)
        {
            var result = new Result<Address>();

            var addressResponse = await _addressApi.GetAddressByZipCode(request.ZipCode, cancellationToken);

            if (addressResponse == null)
            {
                result.AddErrors("Endereço não encontrado.", ErrorType.NotFoundData);
                return result;
            }

            result.SetData(addressResponse.GetAddress());

            return result;
        }
    }
}

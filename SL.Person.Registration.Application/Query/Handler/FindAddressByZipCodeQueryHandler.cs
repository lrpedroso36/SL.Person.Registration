using MediatR;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Domain.External.Contracts;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindAddressByZipCodeQueryHandler : IRequestHandler<FindAddressByZipCodeQuery, ResultBase>
    {
        private readonly IAddressApi _addressApi;

        public FindAddressByZipCodeQueryHandler(IAddressApi addressApi)
        {
            _addressApi = addressApi;
        }

        public async Task<ResultBase> Handle(FindAddressByZipCodeQuery request, CancellationToken cancellationToken)
        {
            var result = request.RequestValidate();

            if (!result.IsSuccess)
            {
                return result;
            }

            var addressResponse = await _addressApi.GetAddressByZipCode(request.ZipCode, cancellationToken);

            if (addressResponse == null)
            {
                result.AddErrors(ResourceMessagesValidation.FindAddressByZipCodeValidation_NotFound, ErrorType.NotFoundData);
                return result;
            }

            var resultAddress = new ResultEntities<Address>();

            resultAddress.SetData(addressResponse.GetAddress());

            return resultAddress;
        }
    }
}

using MediatR;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Commons.Responses.Base;
using SL.Person.Registration.Application.Query.FindAddressByZipCode.Extensions;
using SL.Person.Registration.Domain.External.Contracts;
using SL.Person.Registration.Domain.PersonAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.FindAddressByZipCode;

public class FindAddressByZipCodeQueryHandler : IRequestHandler<FindAddressByZipCodeQuery, ResultBase>
{
    private readonly IAddressApi _addressApi;

    public FindAddressByZipCodeQueryHandler(IAddressApi addressApi)
    {
        _addressApi = addressApi;
    }

    public async Task<ResultBase> Handle(FindAddressByZipCodeQuery request, CancellationToken cancellationToken)
    {
        request.RequestValidate();

        var addressResponse = await _addressApi.GetAddressByZipCode(request.ZipCode, cancellationToken);

        addressResponse.ValidateInstance();

        var result = new ResultEntities<Address>();
        result.SetData(addressResponse.GetAddress());

        return result;
    }
}

using MediatR;
using SL.Person.Registration.Application.Results.Base;

namespace SL.Person.Registration.Application.Query.FindAddressByZipCode;

public class FindAddressByZipCodeQuery : IRequest<ResultBase>
{
    public string ZipCode { get; }

    public FindAddressByZipCodeQuery(string zipCode)
    {
        ZipCode = zipCode;
    }
}

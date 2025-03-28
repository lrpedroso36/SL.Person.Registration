﻿using SL.Person.Registration.Domain.External.Response;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Domain.External.Contracts;

public interface IAddressApi
{
    Task<AddressResponse> GetAddressByZipCodeAsync(string zipCode, CancellationToken cancellationToken);
}

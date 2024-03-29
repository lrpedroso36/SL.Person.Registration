﻿using MediatR;
using SL.Person.Registration.Application.Commons.Responses.Base;

namespace SL.Person.Registration.Application.Query.FindAddressByZipCode;

public class FindAddressByZipCodeQuery : IRequest<ResponseBase>
{
    public string ZipCode { get; }

    public FindAddressByZipCodeQuery(string zipCode)
    {
        ZipCode = zipCode;
    }
}

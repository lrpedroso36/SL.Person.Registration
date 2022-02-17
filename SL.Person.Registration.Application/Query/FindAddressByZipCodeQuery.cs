﻿using MediatR;
using SL.Person.Registration.Domain.Results;

namespace SL.Person.Registration.Application.Query
{
    public class FindAddressByZipCodeQuery : IRequest<ResultBase>
    {
        public string ZipCode { get; }

        public FindAddressByZipCodeQuery(string zipCode)
        {
            ZipCode = zipCode;
        }
    }
}

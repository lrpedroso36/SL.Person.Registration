using MediatR;
using SL.Person.Registration.Application.Query.FindLookup.Responses;
using System;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query.FindLookup;

public class FindLookupQuery : IRequest<IEnumerable<FindLookupResponse>>
{
    public Type EnumType { get; private set; }

    public FindLookupQuery(Type enumType)
    {
        EnumType = enumType;
    }
}

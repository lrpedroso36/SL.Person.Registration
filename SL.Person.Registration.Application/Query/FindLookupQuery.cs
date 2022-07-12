using MediatR;
using SL.Person.Registration.Application.Results;
using System;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query
{
    public class FindLookupQuery : IRequest<IEnumerable<FindLookupResult>>
    {
        public Type EnumType { get; private set; }

        public FindLookupQuery(Type enumType)
        {
            EnumType = enumType;
        }
    }
}

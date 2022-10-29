using MediatR;
using SL.Person.Registratio.CrossCuting.Extensions;
using SL.Person.Registration.Application.Query.FindLookup.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.FindLookup;

public class FindLookupQueryHandler : IRequestHandler<FindLookupQuery, IEnumerable<FindLookupResponse>>
{
    public async Task<IEnumerable<FindLookupResponse>> Handle(FindLookupQuery request, CancellationToken cancellationToken)
    {
        return EnumNamedValues(request.EnumType);
    }

    private IEnumerable<FindLookupResponse> EnumNamedValues(Type enumType)
    {
        var values = Enum.GetValues(enumType).Cast<Enum>().ToList();

        foreach (var item in values)
        {
            yield return new FindLookupResponse()
            {
                Id = Convert.ToInt32(item),
                Name = item.ToString(),
                Description = item.GetDescription()
            };
        }
    }
}

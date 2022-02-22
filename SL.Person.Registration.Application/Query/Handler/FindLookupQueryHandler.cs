using MediatR;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Query.Handler
{
    public class FindLookupQueryHandler : IRequestHandler<FindLookupQuery, IEnumerable<FindLookupResult>>
    {
        public async Task<IEnumerable<FindLookupResult>> Handle(FindLookupQuery request, CancellationToken cancellationToken)
        {
            return EnumNamedValues(request.EnumType);
        }

        private IEnumerable<FindLookupResult> EnumNamedValues(Type enumType)
        {
            var values = Enum.GetValues(enumType).Cast<Enum>().ToList();

            foreach (var item in values)
            {
                yield return new FindLookupResult()
                {
                    Id = Convert.ToInt32(item),
                    Name = item.ToString(),
                    Description = item.GetDescription()
                };
            }
        }
    }
}

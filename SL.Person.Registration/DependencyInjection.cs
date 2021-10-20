using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SL.Person.Registration.Application.Query;

namespace SL.Person.Registration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMediatorQuery(this IServiceCollection service)
        {
            service.AddMediatR(typeof(FindLookupQuery).GetTypeInfo().Assembly);
            return service;
        }
    }
}

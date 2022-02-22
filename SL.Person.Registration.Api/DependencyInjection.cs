using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SL.Person.Registratio.CrossCuting.Configurations;
using SL.Person.Registratio.CrossCuting.Configurations.Contracts;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Configurations;
using SL.Person.Registration.Domain.External.Contracts;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Infrastructure.External.Api;
using SL.Person.Registration.Infrastructure.MongoDb.Contexts;
using SL.Person.Registration.Infrastructure.MongoDb.Contexts.Contracts;
using SL.Person.Registration.Infrastructure.MongoDb.Repositories;
using System.Reflection;

namespace SL.Person.Registration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMediatorQuery(this IServiceCollection service)
        {
            var assembly = typeof(FindLookupQuery).GetTypeInfo().Assembly;
            service.AddMediatR(assembly);
            return service;
        }

        public static IServiceCollection AddConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<MongoSettings>(configuration.GetSection("MongoSettings"));
            service.Configure<AddressApiSettings>(configuration.GetSection("AddressApiSettings"));

            service.AddSingleton<IConfigurationPersonRegistration, ConfigurationPersonRegistration>();
            return service;
        }

        public static IServiceCollection AddInfraestructure(this IServiceCollection service)
        {
            service.AddScoped<IPersonRegistrationDbContext<PersonRegistration>, PersonRegistrationDbContext>();

            service.AddScoped<IPersonRegistrationRepository, PersonRegistrationRepository>();
            return service;
        }


        public static IServiceCollection AddInfraestructureExternal(this IServiceCollection service)
        {
            service.AddScoped<IAddressApi, AddressApi>();
            return service;
        }
    }
}

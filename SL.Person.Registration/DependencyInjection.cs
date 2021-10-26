using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SL.Person.Registratio.CrossCuting.Configurations;
using SL.Person.Registratio.CrossCuting.Configurations.Contracts;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Configurations;
using SL.Person.Registration.Domain.RegistrationAggregate;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Infrastructure.MongoDb.Contexts;
using SL.Person.Registration.Infrastructure.MongoDb.Contexts.Contracts;
using SL.Person.Registration.Infrastructure.MongoDb.Repositories;

namespace SL.Person.Registration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMediatorQuery(this IServiceCollection service)
        {
            service.AddMediatR(typeof(FindLookupQuery).GetTypeInfo().Assembly);
            service.AddMediatR(typeof(FindPersonByDocumentQuery).GetTypeInfo().Assembly);
            return service;
        }

        public static IServiceCollection AddMediatorCommand(this IServiceCollection service)
        {
            service.AddMediatR(typeof(InsertPersonCommand).GetTypeInfo().Assembly);
            return service;
        }

        public static IServiceCollection AddConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<MongoConnection>(configuration.GetSection("MongoConnection"));

            service.AddSingleton<IConfigurationPersonRegistration, ConfigurationPersonRegistration>();
            return service;
        }

        public static IServiceCollection AddInfraestructure(this IServiceCollection service)
        {
            service.AddTransient<IInformationRegistrationDbContext<InformationRegistration>, InformationRegistrationDbContext>();

            service.AddTransient<IInformationRegistrationRepository, PersonRegistrationRepository>();
            return service;
        }

    }
}

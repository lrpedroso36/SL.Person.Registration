using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SL.Person.Registration.CrossCuting.Configurations;
using SL.Person.Registration.Domain.Configurations;
using SL.Person.Registration.Domain.Configurations.Settings;
using SL.Person.Registration.Domain.External.Contracts;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Infrastructure.External.Api;
using SL.Person.Registration.Infrastructure.Postgresql.Context;
using SL.Person.Registration.Infrastructure.Postgresql.Repositories;
using System;

namespace SL.Person.Registration.CrossCuting;

public static class DependencyInjection
{
    public static IServiceCollection AddConfiguration(this IServiceCollection service, IConfiguration configuration)
    {
        service.Configure<AddressApiSettings>(configuration.GetSection("AddressApiSettings"));

        service.AddSingleton<IConfigurationPersonRegistration, ConfigurationPersonRegistration>();
        return service;
    }

    public static IServiceCollection AddInfraestructureExternal(this IServiceCollection service)
    {
        service.AddScoped<IAddressApi, AddressApi>();
        return service;
    }

    public static IServiceCollection AddInfraestructure(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<IPersonRegistrationRepository, PersonRegistrationRepository>();

        service.AddDbContextPool<ApplicationDbContext>(opt => opt
            .UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return service;
    }

    public static IServiceCollection AddMediator(this IServiceCollection service)
    {
        var assembly = AppDomain.CurrentDomain.Load("SL.Person.Registration.Application");
        service.AddMediatR(assembly);
        return service;
    }
}

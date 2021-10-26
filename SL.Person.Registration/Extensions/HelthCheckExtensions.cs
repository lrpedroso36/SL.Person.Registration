﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SL.Person.Registration.Extensions
{
    public static class HelthCheckExtensions
    {
        public static IServiceCollection AddAppHealthCheck(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
            var dataBaseName = configuration.GetSection("MongoConnection:PersoRegistration").Value;

            service.AddHealthChecks()
                   .AddMongoDb(connectionString, dataBaseName, name: "mongodb", failureStatus: HealthStatus.Unhealthy);

            return service;
        }
    }
}

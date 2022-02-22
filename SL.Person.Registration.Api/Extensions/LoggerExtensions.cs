using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Serilog;

namespace SL.Person.Registration.Extensions
{
    public static class LoggerExtensions
    {
        private const string MongoConnectionString = "MongoSettings:ConnectionString";
        private const string MongoDataLoggerDataBase = "MongoSettings:LoggerCollection";

        public static IConfigurationBuilder AddConfigurationSerilog(this IConfigurationBuilder config)
        {
            var dataBase = config.Build().GetValue<string>(MongoDataLoggerDataBase);
            var connectionString = config.Build().GetValue<string>(MongoConnectionString);

            var client = new MongoClient(new MongoUrl(connectionString));
            var database = client.GetDatabase(dataBase);

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.MongoDB(database, collectionName: "SLPersonRegistration")
                .CreateLogger();
            return config;
        }
    }
}

using Microsoft.Extensions.Options;
using SL.Person.Registratio.CrossCuting.Configurations;
using SL.Person.Registratio.CrossCuting.Configurations.Contracts;

namespace SL.Person.Registration.Configurations
{
    public class ConfigurationPersonRegistration : IConfigurationPersonRegistration
    {
        private readonly IOptions<MongoConnection> _configuration;

        public ConfigurationPersonRegistration(IOptions<MongoConnection> configuration)
        {
            _configuration = configuration;
        }

        public MongoConnection GetMongoConnection()
        {
            return _configuration.Value;
        }
    }
}

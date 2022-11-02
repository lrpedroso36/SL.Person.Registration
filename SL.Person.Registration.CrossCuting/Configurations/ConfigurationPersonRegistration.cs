using Microsoft.Extensions.Options;
using SL.Person.Registration.Domain.Configurations;
using SL.Person.Registration.Domain.Configurations.Settings;

namespace SL.Person.Registration.CrossCuting.Configurations;

public class ConfigurationPersonRegistration : IConfigurationPersonRegistration
{
    private readonly IOptions<MongoSettings> _mongoSettings;
    private readonly IOptions<AddressApiSettings> _addressApiSettings;

    public ConfigurationPersonRegistration(IOptions<MongoSettings> mongoSettings,
                                           IOptions<AddressApiSettings> addressApiSettings)
    {
        _mongoSettings = mongoSettings;
        _addressApiSettings = addressApiSettings;
    }

    public AddressApiSettings GetAddressApiSettings()
        => _addressApiSettings.Value;

    public MongoSettings GetMongoSettings()
        => _mongoSettings.Value;
}

using SL.Person.Registration.Domain.Configurations.Settings;

namespace SL.Person.Registration.Domain.Configurations
{
    public interface IConfigurationPersonRegistration
    {
        MongoSettings GetMongoSettings();

        AddressApiSettings GetAddressApiSettings();
    }
}

using SL.Person.Registration.Domain.Configurations.Settings;

namespace SL.Person.Registration.Domain.Configurations
{
    public interface IConfigurationPersonRegistration
    {
        PostgreSettings GetMongoSettings();

        AddressApiSettings GetAddressApiSettings();
    }
}

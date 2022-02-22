namespace SL.Person.Registratio.CrossCuting.Configurations.Contracts
{
    public interface IConfigurationPersonRegistration
    {
        MongoSettings GetMongoSettings();

        AddressApiSettings GetAddressApiSettings();
    }
}

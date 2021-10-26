namespace SL.Person.Registratio.CrossCuting.Configurations.Contracts
{
    public interface IConfigurationPersonRegistration
    {
        MongoConnection GetMongoConnection();
    }
}

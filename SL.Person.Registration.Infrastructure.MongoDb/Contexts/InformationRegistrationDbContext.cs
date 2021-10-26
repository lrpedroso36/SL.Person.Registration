using System;
using MongoDB.Driver;
using SL.Person.Registratio.CrossCuting.Configurations.Contracts;
using SL.Person.Registration.Domain.RegistrationAggregate;
using SL.Person.Registration.Infrastructure.MongoDb.Contexts.Contracts;

namespace SL.Person.Registration.Infrastructure.MongoDb.Contexts
{
    public class InformationRegistrationDbContext : IInformationRegistrationDbContext<InformationRegistration>
    {
        private readonly IMongoDatabase _dataBase;
        private readonly string _personRegistrationCollection;

        public InformationRegistrationDbContext(IConfigurationPersonRegistration configuration)
        {
            try
            {
                var mongoConnection = configuration.GetMongoConnection();

                _personRegistrationCollection = mongoConnection.InformationRegistrationCollection;

                var client = new MongoClient(new MongoUrl(mongoConnection.ConnectionString));
                _dataBase = client.GetDatabase(_personRegistrationCollection);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IMongoCollection<InformationRegistration> Collection
        {
            get
            {
                return _dataBase.GetCollection<InformationRegistration>(_personRegistrationCollection);
            }
        }
    }
}

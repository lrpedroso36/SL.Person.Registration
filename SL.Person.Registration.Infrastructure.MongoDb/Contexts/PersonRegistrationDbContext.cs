using MongoDB.Driver;
using SL.Person.Registratio.CrossCuting.Configurations.Contracts;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Infrastructure.MongoDb.Contexts.Contracts;
using System;

namespace SL.Person.Registration.Infrastructure.MongoDb.Contexts
{
    public class PersonRegistrationDbContext : IPersonRegistrationDbContext<PersonRegistration>
    {
        private readonly IMongoDatabase _dataBase;
        private readonly string _personRegistrationCollection;

        public PersonRegistrationDbContext(IConfigurationPersonRegistration configuration)
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

        public IMongoCollection<PersonRegistration> Collection
        {
            get
            {
                return _dataBase.GetCollection<PersonRegistration>(_personRegistrationCollection);
            }
        }
    }
}

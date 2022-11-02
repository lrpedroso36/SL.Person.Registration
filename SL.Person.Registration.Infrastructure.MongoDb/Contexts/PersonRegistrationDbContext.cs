using MongoDB.Driver;
using SL.Person.Registration.Domain.Configurations;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Infrastructure.MongoDb.Contexts.Contracts;
using System;

namespace SL.Person.Registration.Infrastructure.MongoDb.Contexts;

public class PersonRegistrationDbContext : IPersonRegistrationDbContext<PersonRegistration>
{
    private readonly IMongoDatabase _dataBase;
    private readonly string _personRegistrationCollection;

    public PersonRegistrationDbContext(IConfigurationPersonRegistration configuration)
    {
        try
        {
            var mongoSettings = configuration.GetMongoSettings();

            _personRegistrationCollection = mongoSettings.PersonCollection;

            var client = new MongoClient(new MongoUrl(mongoSettings.ConnectionString));
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

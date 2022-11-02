using MongoDB.Driver;

namespace SL.Person.Registration.Infrastructure.MongoDb.Contexts.Contracts;

public interface IPersonRegistrationDbContext<T> where T : class
{
    public IMongoCollection<T> Collection { get; }
}

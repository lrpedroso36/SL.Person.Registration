using MongoDB.Driver;

namespace SL.Person.Registration.Infrastructure.MongoDb.Contexts.Contracts
{
    public interface IInformationRegistrationDbContext<T> where T : class
    {
        public IMongoCollection<T> Collection { get; }
    }
}

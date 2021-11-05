using MongoDB.Driver;
using SL.Person.Registration.Domain.RegistrationAggregate;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Infrastructure.MongoDb.Contexts.Contracts;

namespace SL.Person.Registration.Infrastructure.MongoDb.Repositories
{
    public class PersonRegistrationRepository : IInformationRegistrationRepository
    {
        private readonly IInformationRegistrationDbContext<InformationRegistration> _context;

        public PersonRegistrationRepository(IInformationRegistrationDbContext<InformationRegistration> context)
        {
            _context = context;
        }

        public InformationRegistration GetByDocument(long documentNumber)
        {
            var filter = Builders<InformationRegistration>.Filter.Lte("PersonRegistration.DocumentNumber", documentNumber);

            var result = _context.Collection.Find(filter).FirstOrDefault();

            return result;
        }

        public void Insert(InformationRegistration registration)
        {
            _context.Collection.InsertOne(registration);
        }

        public bool Update(InformationRegistration registration)
        {
            _context.Collection.ReplaceOneAsync(x => x._id == registration._id, registration);
            return true;
        }
    }
}

using MongoDB.Driver;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Infrastructure.MongoDb.Contexts.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Infrastructure.MongoDb.Repositories
{
    public class PersonRegistrationRepository : IPersonRegistrationRepository
    {
        private readonly IPersonRegistrationDbContext<PersonRegistration> _context;

        public PersonRegistrationRepository(IPersonRegistrationDbContext<PersonRegistration> context)
        {
            _context = context;
        }

        public PersonRegistration GetByContactNumber(int ddd, long phoneNumber)
        {
            return _context.Collection.AsQueryable().FirstOrDefault(x => x.Contact != null && x.Contact.DDD == ddd && x.Contact.PhoneNumber == phoneNumber);
        }

        public PersonRegistration GetByDocument(long documentNumber)
        {
            return _context.Collection.AsQueryable().FirstOrDefault(x => x.DocumentNumber == documentNumber);
        }

        public IEnumerable<PersonRegistration> GetByName(string name)
        {
            return _context.Collection.AsQueryable().Where(x => x.Name.ToLower().StartsWith(name.ToLower()));
        }

        public void Insert(PersonRegistration registration)
        {
            _context.Collection.InsertOne(registration);
        }

        public bool Update(PersonRegistration registration)
        {
            _context.Collection.ReplaceOneAsync(x => x._id == registration._id, registration);
            return true;
        }
    }
}

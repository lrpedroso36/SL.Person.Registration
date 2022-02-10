using MongoDB.Driver;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
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
            => _context.Collection.AsQueryable().FirstOrDefault(x => x.Contact != null && x.Contact.DDD == ddd && x.Contact.PhoneNumber == phoneNumber);

        public PersonRegistration GetByDocument(long documentNumber)
            => _context.Collection.AsQueryable().FirstOrDefault(x => x.DocumentNumber == documentNumber);

        public PersonRegistration GetByDocument(long documentNumber, PersonType personType)
            => _context.Collection.AsQueryable().FirstOrDefault(x => x.DocumentNumber == documentNumber && x.Types.Contains(personType));

        public IEnumerable<PersonRegistration> GetByName(string name)
            => _context.Collection.AsQueryable().Where(x => x.Name.ToLower().StartsWith(name.ToLower()));

        public void Insert(PersonRegistration registration)
            => _context.Collection.InsertOne(registration);

        public bool Update(PersonRegistration registration)
        {
            _context.Collection.ReplaceOneAsync(x => x._id == registration._id, registration);
            return true;
        }
    }
}

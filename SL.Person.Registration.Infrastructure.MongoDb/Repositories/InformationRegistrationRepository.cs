using MongoDB.Bson;
using MongoDB.Driver;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Infrastructure.MongoDb.Contexts.Contracts;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SL.Person.Registration.Infrastructure.MongoDb.Repositories
{
    public class PersonRegistrationRepository : IPersonRepository
    {
        private readonly IPersonRegistrationDbContext<PersonRegistration> _context;

        public PersonRegistrationRepository(IPersonRegistrationDbContext<PersonRegistration> context)
        {
            _context = context;
        }

        public PersonRegistration GetByContactNumber(int ddd, long phoneNumber)
        {
            var filterDDD = Builders<PersonRegistration>.Filter.Lte("Contact.DDD", ddd);
            var filterPhoneNumber = Builders<PersonRegistration>.Filter.Lte("Contact.PhoneNumber", phoneNumber);
            var filter = Builders<PersonRegistration>.Filter.And(filterDDD, filterPhoneNumber);

            var result = _context.Collection.Find(filter).FirstOrDefault();

            return result;
        }

        public PersonRegistration GetByDocument(long documentNumber)
        {
            var filter = Builders<PersonRegistration>.Filter.Lte("DocumentNumber", documentNumber);

            var result = _context.Collection.Find(filter).FirstOrDefault();

            return result;
        }

        public IEnumerable<PersonRegistration> GetByName(string name)
        {
            var queryExpr = new BsonRegularExpression(new Regex($"^{name}.*", RegexOptions.None));

            var builder = Builders<PersonRegistration>.Filter;
            var filter = builder.Regex("Name", queryExpr);

            var result = _context.Collection.Find(filter).ToList();

            return result;
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

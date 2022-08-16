using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Infrastructure.MongoDb.Contexts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Infrastructure.MongoDb.Repositories
{
    public class PersonRegistrationRepository : IPersonRegistrationRepository
    {
        private readonly IPersonRegistrationDbContext<PersonRegistration> _context;

        public PersonRegistrationRepository(IPersonRegistrationDbContext<PersonRegistration> context)
            => (_context) = context;

        public IEnumerable<PersonRegistration> Get(PersonType? personType, string name, long documentNumber)
        {
            var builder = Builders<PersonRegistration>.Filter;
            var filter = builder.Eq(x => x.IsExcluded, false);

            if (personType.HasValue && personType.Value != PersonType.Todos)
            {
                filter &= builder.AnyEq(x => x.Types, personType.Value);
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                filter &= builder.Regex(x => x.Name, $"/.*{name.ToUpper()}.*/");
            }

            if (documentNumber != 0)
            {
                filter &= builder.Eq(x => x.DocumentNumber, documentNumber);
            }

            return _context.Collection.Find(filter).ToList();
        }

        public PersonRegistration GetByDocument(long documentNumber)
            => _context.Collection.AsQueryable().FirstOrDefault(x => x.DocumentNumber == documentNumber && !x.IsExcluded);

        public PersonRegistration GetByDocument(long documentNumber, PersonType personType)
            => _context.Collection.AsQueryable().FirstOrDefault(x => x.DocumentNumber == documentNumber && x.Types.Contains(personType) && !x.IsExcluded);

        public PersonRegistration GetById(string id)
            => _context.Collection.AsQueryable().FirstOrDefault(x => x._id == new Guid(id) && !x.IsExcluded);

        public IEnumerable<PersonRegistration> GetByName(string name)
            => _context.Collection.AsQueryable().Where(x => x.Name.ToLower().StartsWith(name.ToLower()) && !x.IsExcluded).ToList();

        public IEnumerable<PersonRegistration> GetByName(string name, PersonType personType)
            => _context.Collection.AsQueryable().Where(x => x.Name.ToLower().StartsWith(name.ToLower()) && x.Types.Contains(personType) && !x.IsExcluded).ToList();

        public void Insert(PersonRegistration registration)
            => _context.Collection.InsertOne(registration);

        public void Update(PersonRegistration registration)
            => _context.Collection.ReplaceOneAsync(x => x._id == registration._id, registration);
    }

}

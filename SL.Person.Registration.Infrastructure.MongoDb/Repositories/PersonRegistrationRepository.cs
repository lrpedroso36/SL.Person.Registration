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

        public PersonRegistration GetByDocument(long documentNumber)
            => _context.Collection.AsQueryable().FirstOrDefault(x => x.DocumentNumber == documentNumber && !x.IsExcluded);

        public PersonRegistration GetByDocument(long documentNumber, PersonType personType)
            => _context.Collection.AsQueryable().FirstOrDefault(x => x.DocumentNumber == documentNumber && x.Types.Contains(personType) && !x.IsExcluded);

        public IEnumerable<PersonRegistration> GetByName(string name)
            => _context.Collection.AsQueryable().Where(x => x.Name.ToLower().StartsWith(name.ToLower()) && !x.IsExcluded).ToList();

        public IEnumerable<PersonRegistration> GetByType(PersonType personType)
            => _context.Collection.AsQueryable().Where(x => x.Types.Contains(personType) && !x.IsExcluded).ToList();

        public void Insert(PersonRegistration registration)
            => _context.Collection.InsertOne(registration);

        public void Update(PersonRegistration registration)
            => _context.Collection.ReplaceOneAsync(x => x._id == registration._id, registration);
    }
}

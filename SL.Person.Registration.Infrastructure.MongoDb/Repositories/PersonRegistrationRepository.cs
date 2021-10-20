using System;
using System.Threading;
using System.Threading.Tasks;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;

namespace SL.Person.Registration.Infrastructure.MongoDb.Repositories
{
    public class PersonRegistrationRepository : IRegistrationRepository
    {
        public PersonRegistrationRepository()
        {
        }

        public Task<PersonRegistration> GetPerson(long documentNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(PersonRegistration person, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

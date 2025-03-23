using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;

namespace SL.Person.Registration.Infrastructure.Postgresql.Repositories;

public class PersonRegistrationRepository : IPersonRegistrationRepository
{
    public Task<IEnumerable<PersonRegistration>?> GetAsync(Guid? personType, string name, long documentNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PersonRegistration?> GetByDocumentASync(long documentNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PersonRegistration?> GetByDocumentAsync(long documentNumber, Guid personTypeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PersonRegistration?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PersonRegistration>?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PersonRegistration>?> GetByNameAsync(string name, Guid personTypeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync(PersonRegistration registration, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(PersonRegistration registration, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

using SL.Person.Registration.Domain.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Domain.Repositories;

public interface IPersonRegistrationRepository
{
    Task InsertAsync(PersonRegistration registration, CancellationToken cancellationToken);
    Task<PersonRegistration?> GetByDocumentASync(long documentNumber, CancellationToken cancellationToken);
    Task<IEnumerable<PersonRegistration>?> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task<IEnumerable<PersonRegistration>?> GetByNameAsync(string name, Guid personTypeId, CancellationToken cancellationToken);
    Task UpdateAsync(PersonRegistration registration, CancellationToken cancellationToken);
    Task<PersonRegistration?> GetByDocumentAsync(long documentNumber, Guid personTypeId, CancellationToken cancellationToken);
    Task<IEnumerable<PersonRegistration>?> GetAsync(Guid? personTypeId, string name, long documentNumber, CancellationToken cancellationToken);
    Task<PersonRegistration?> GetByIdAsync(string id, CancellationToken cancellationToken);
}

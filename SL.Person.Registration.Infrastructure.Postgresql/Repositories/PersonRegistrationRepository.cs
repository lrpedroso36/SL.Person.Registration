using Microsoft.EntityFrameworkCore;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Infrastructure.Postgresql.Context;

namespace SL.Person.Registration.Infrastructure.Postgresql.Repositories;

public class PersonRegistrationRepository(ApplicationDbContext context) : IPersonRegistrationRepository
{
    private readonly ApplicationDbContext _context;

    public Task<IEnumerable<PersonRegistration>?> GetAsync(Guid? personType, string name, long documentNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PersonRegistration?> GetByDocumentASync(long documentNumber, CancellationToken cancellationToken)
    {
        return await _context.PersonRegistrations.FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber &&
                                                        x.IsExcluded, cancellationToken);
    }

    public async Task<PersonRegistration?> GetByDocumentAsync(long documentNumber, Guid personTypeId, CancellationToken cancellationToken)
    {
        return await _context.PersonRegistrations.FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber &&
                                                        x.PersonRegistrationPersonTypes.Any(x => x.PersonType.Id == personTypeId) &&
                                                        x.IsExcluded, cancellationToken);
    }

    public async Task<PersonRegistration?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        return await _context.PersonRegistrations.FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<PersonRegistration>?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _context.PersonRegistrations.Where(x => x.Name.ToLower() == name.ToLower() &&
                                                             x.IsExcluded).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<PersonRegistration>?> GetByNameAsync(string name, Guid personTypeId, CancellationToken cancellationToken)
    {
        return await _context.PersonRegistrations.Where(x => x.Name.ToLower() == name.ToLower() &&
                                                        x.PersonRegistrationPersonTypes.Any(x => x.PersonType.Id == personTypeId) &&
                                                        x.IsExcluded).ToListAsync(cancellationToken);
    }

    public async Task InsertAsync(PersonRegistration registration, CancellationToken cancellationToken)
    {
        _context.Add(registration);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(PersonRegistration registration, CancellationToken cancellationToken)
    {
        _context.Update(registration);
        await _context.SaveChangesAsync(cancellationToken);
    }
}

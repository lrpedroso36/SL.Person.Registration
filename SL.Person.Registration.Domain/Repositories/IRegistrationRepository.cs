using System.Threading;
using System.Threading.Tasks;
using SL.Person.Registration.Domain.RegistrationAggregate;

namespace SL.Person.Registration.Domain.Repositories
{
    public interface IRegistrationRepository
    {
        Task<bool> Insert(InformationRegistration registration, CancellationToken cancellationToken);

        Task<InformationRegistration> GetPerson(long documentNumber, CancellationToken cancellationToken); 
    }
}

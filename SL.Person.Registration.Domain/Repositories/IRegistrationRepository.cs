using System.Threading;
using System.Threading.Tasks;
using SL.Person.Registration.Domain.RegistrationAggregate;

namespace SL.Person.Registration.Domain.Repositories
{
    public interface IRegistrationRepository
    {
        Task<bool> Insert(InformationRegistration registration, CancellationToken cancellationToken);

        Task<InformationRegistration> Get(long documentNumber, CancellationToken cancellationToken);

        Task<InformationRegistration> Update(InformationRegistration registration, CancellationToken cancellationToken);
    }
}

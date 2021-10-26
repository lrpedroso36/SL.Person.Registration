using SL.Person.Registration.Domain.RegistrationAggregate;

namespace SL.Person.Registration.Domain.Repositories
{
    public interface IInformationRegistrationRepository
    {
        void Insert(InformationRegistration registration);

        InformationRegistration GetByDocument(long documentNumber);

        bool Update(InformationRegistration registration);
    }
}

using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System.Collections.Generic;

namespace SL.Person.Registration.Domain.Repositories
{
    public interface IPersonRegistrationRepository
    {
        void Insert(PersonRegistration registration);
        PersonRegistration GetByDocument(long documentNumber);
        IEnumerable<PersonRegistration> GetByName(string name);
        IEnumerable<PersonRegistration> GetByName(string name, PersonType personType);
        void Update(PersonRegistration registration);
        PersonRegistration GetByDocument(long documentNumber, PersonType personType);
        IEnumerable<PersonRegistration> Get(PersonType? personType, string name, long documentNumber);
        PersonRegistration GetById(string id);
    }
}

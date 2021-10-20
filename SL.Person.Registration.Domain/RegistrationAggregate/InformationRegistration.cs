using System.Collections.Generic;
using SL.Person.Registration.Domain.InterViewAggregate;
using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Domain.RegistrationAggregate
{
    public class InformationRegistration
    {
        public PersonRegistration PersonRegistration { get; private set; }

        public List<Interview > Interviews { get; private set; }
    }
}

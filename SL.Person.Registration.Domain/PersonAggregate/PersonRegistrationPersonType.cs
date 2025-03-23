using SL.Person.Registration.Domain.PersonAggregate.Base;
using System;

namespace SL.Person.Registration.Domain.PersonAggregate;

public class PersonRegistrationPersonType : Entity
{
    public Guid PersonRegistrationId { get; private set; }
    public PersonRegistration PersonRegistration { get; private set; }
    public Guid PersonTypeId { get; private set; }
    public PersonType PersonType { get; private set; } 

    protected PersonRegistrationPersonType()
    {
        
    }

    protected PersonRegistrationPersonType(PersonRegistration personRegistration, PersonType personType)
    {
        PersonRegistration = personRegistration;
        PersonType = personType;
    }

    public static PersonRegistrationPersonType CreateInstance(PersonRegistration personRegistration, PersonType personType)
        => new(personRegistration, personType);
}

using SL.Person.Registration.Domain.PersonAggregate.Base;
using System;

namespace SL.Person.Registration.Domain.PersonAggregate;

public class Contact : Entity
{
    public int DDD { get; private set; }

    public string PhoneNumber { get; private set; }

    public Guid PersonRegistrationId { get; set; }
    public PersonRegistration PersonRegistration { get; set; }

    protected Contact()
    {

    }

    protected Contact(int ddd, string phoneNumber)
    {
        DDD = ddd;
        PhoneNumber = phoneNumber;
    }

    public static Contact CreateInstance(int ddd, string phoneNumber)
        => new Contact(ddd, phoneNumber);
}

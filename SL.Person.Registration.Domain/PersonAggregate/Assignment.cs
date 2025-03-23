using SL.Person.Registration.Domain.PersonAggregate.Base;
using System;

namespace SL.Person.Registration.Domain.PersonAggregate;

public class Assignment : Entity
{
    public DateTime Date { get; private set; }

    public bool Presence { get; private set; }

    public Guid PersonRegistrationId { get; set; }
    public PersonRegistration PersonRegistration { get; set; }

    protected Assignment()
    {

    }

    protected Assignment(DateTime date, bool presence)
    {
        Date = date;
        Presence = presence;
    }

    public static Assignment CreateInstance(DateTime date, bool presence)
        => new Assignment(date, presence);
}

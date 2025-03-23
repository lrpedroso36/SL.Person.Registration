using System;

namespace SL.Person.Registration.Domain.PersonAggregate.Base;

public abstract class Entity
{
    public Guid Id { get; set; }
}

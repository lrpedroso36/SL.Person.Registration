using SL.Person.Registration.Domain.PersonAggregate.Base;
using System;

namespace SL.Person.Registration.Domain.PersonAggregate;

public class PersonType : Entity
{
    public string Name { get; private set; }

    protected PersonType()
    {

    }

    protected PersonType(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static PersonType All()
        => new(new Guid("87565733-c273-4163-90b5-081ecc354170"), "Todos");

    public static PersonType Tarefeiro()
        => new(new Guid("35b731eb-0895-4a94-86b0-4436fd80db4c"), "Tarefeiro");

    public static PersonType Assistido()
        => new(new Guid("03b340ee-292c-412a-b909-386eda4d99e3"), "Assistido");

    public static PersonType Palestrante()
        => new(new Guid("21a7e47d-4781-48cc-a587-dfd55c5581e6"), "Palestrante");

    public static PersonType Entrevistador()
        => new(new Guid("dbacb66e-e460-48a8-b4e7-bbb6852859d9"), "Entrevistador");
}

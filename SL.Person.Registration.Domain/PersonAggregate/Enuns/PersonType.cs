using System.ComponentModel;

namespace SL.Person.Registration.Domain.PersonAggregate.Enuns;

public enum PersonType
{
    [Description("Todos")]
    Todos = 0,

    [Description("Tarefeiro")]
    Tarefeiro = 1,

    [Description("Assistido")]
    Assistido = 2,

    [Description("Palestrante")]
    Palestrante = 3,

    [Description("Entrevistador")]
    Entrevistador = 4
}

using System.ComponentModel;

namespace SL.Person.Registration.Domain.PersonAggregate.Enuns;

public enum WeakDayType
{
    [Description("As Quartas-feiras")]
    QuartaFeira = 3,

    [Description("As Quintas-feiras")]
    QuintaFeira = 4,

    [Description("As Sextas-feiras")]
    SextaFeira = 5,

    [Description("Aos Sábados")]
    Sabado = 6
}

using System.ComponentModel;

namespace SL.Person.Registration.Domain.PersonAggregate.Enuns;

public enum TreatmentType
{
    [Description("Tratamento Espíritual")]
    TratamentoEspiritual = 1,

    [Description("Passe A2")]
    PasseA2 = 2,

    [Description("Passe A3")]
    PasseA3 = 3,

    [Description("Harmonização")]
    Harmonizacao = 4,

    [Description("Capitação")]
    Captacao = 5,

    [Description("Passe P4")]
    PasseP4 = 6,

    [Description("Passe P4-1")]
    PasseP41 = 7,

    [Description("Passe de Limpeza")]
    PasseLimpeza = 8
}

using System.ComponentModel;

namespace SL.Person.Registration.Domain.PersonAggregate.Enuns;

public enum TratamentStatus
{
    [Description("Em progresso")]
    InProcess = 1,

    [Description("Concluído")]
    Concluded = 2,

    [Description("Abandonou")]
    Abandoned = 3
}

using System.ComponentModel;

namespace SL.Person.Registration.Domain.PersonAggregate.Enuns;

public enum InterviewType
{
    [Description("Primeira entrevista")]
    Primeira = 1,

    [Description("Retorno entrevista")]
    Retorno = 2
}

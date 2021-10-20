using System.ComponentModel;

namespace SL.Person.Registration.Domain.InterViewAggregate.Enuns
{
    public enum InterviewType
    {
        [Description("Primeira entrevista")]
        Primeira = 1,

        [Description("Retorno entrevista")]
        Retorno = 2
    }
}

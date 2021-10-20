using System.ComponentModel;

namespace SL.Person.Registration.Domain.PersonAggregate.Enuns
{
    public enum PersonType
    {
        [Description("Usuário do sistema")]
        Usuario = 1,

        [Description("Tarefeiro")]
        Tarefeiro = 2,

        [Description("Assistido")]
        Assistido = 3,

        [Description("Palestrante")]
        Palestrante = 4,

        [Description("Entrevistador")]
        Entrevistador = 5
    }
}

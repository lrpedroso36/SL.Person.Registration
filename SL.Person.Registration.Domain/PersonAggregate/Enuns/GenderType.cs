using System.ComponentModel;

namespace SL.Person.Registration.Domain.PersonAggregate.Enuns
{
    public enum GenderType
    {
        [Description("Masculino")]
        Masculino = 1,

        [Description("Feminio")]
        Feminio = 2,

        [Description("Outros")]
        Outros = 3
    }
}

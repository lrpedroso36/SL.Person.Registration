using System.ComponentModel;

namespace SL.Person.Registration.Domain.InterViewAggregate.Enuns
{
    public enum TreatmentType
    {
        [Description("Passe de Limpeza")]
        PasseLimpeza = 1,

        [Description("Passe Rosa")]
        PesseRosa = 2,

        [Description("Passe A3")]
        PasseA3 = 3
    }
}

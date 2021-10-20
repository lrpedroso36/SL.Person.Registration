using System.ComponentModel;

namespace SL.Person.Registration.Domain.DonationAggregate.Enuns
{
    public enum ReceiveType
    {
       [Description("Doação")]
       Doacao = 1,

       [Description("Beneficiado")]
       Beneficiado = 2
    }
}

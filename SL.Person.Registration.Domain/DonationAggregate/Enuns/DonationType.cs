using System;
using System.ComponentModel;

namespace SL.Person.Registration.Domain.DonationAggregate.Enuns
{
    public enum DonationType
    {
        [Description("Compra (Livros, chaveiro, etc)")]
        Compra = 1,

        [Description("Dinheiro")]
        Dinheiro = 2,

        [Description("Produto (Cesta básica, Alimentos, Produtos de limpeza, Capos descartáveis, etc)")]
        Produto = 4
    }
}

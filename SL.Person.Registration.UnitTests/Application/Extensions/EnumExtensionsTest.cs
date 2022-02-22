using FluentAssertions;
using SL.Person.Registration.Application.Extensions;
using System.ComponentModel;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Extensions
{
    public class EnumExtensionsTest
    {
        [Theory]
        [InlineData(Teste.Teste1, "Teste 1")]
        [InlineData(Teste.Teste2, "Teste 2")]
        public void Should_get_description_enum(Teste enumTeste, string description)
        {
            //arrage
            //act
            var result = enumTeste.GetDescription();

            //assert
            result.Should().Be(description);
        }
    }

    public enum Teste
    {
        [Description("Teste 1")]
        Teste1,

        [Description("Teste 2")]
        Teste2
    }
}

using FluentAssertions;
using SL.Person.Registration.Domain.External.Response;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.External.Response
{
    public class AddressResponseTest
    {
        [Fact]
        public void Should_return_address()
        {
            //arrage
            var zipCode = 13295000;
            var street = "Rua um";
            var neighborhood = "Nova Tuiuti";
            var city = "Itupeva";
            var state = "SP";

            var response = new AddressResponse()
            {
                Cep = "13295-000",
                Logradouro = "Rua um",
                Bairro = "Nova Tuiuti",
                Localidade = "Itupeva",
                Uf = "SP"
            };

            //act
            var address = response.GetAddress();

            //assert
            address.ZipCode.Should().Be(zipCode);
            address.Street.Should().Be(street);
            address.City.Should().Be(city);
            address.State.Should().Be(state);
            address.Neighborhood.Should().Be(neighborhood);
        }
    }
}

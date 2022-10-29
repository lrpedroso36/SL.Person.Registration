using FluentAssertions;
using SL.Person.Registration.Application.Commons.Requests;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Requests
{
    public class AddressRequestTest
    {
        [Theory]
        [InlineData("123456789", "Rua", "Numero", "bairro", "Complemento", "Cidade", "Estado")]
        public void Should_get_address(string zipCode, string street, string number, string neighborhood, string complement, string city, string state)
        {
            //arrange
            var result = new AddressRequest()
            {
                ZipCode = zipCode,
                Street = street,
                Number = number,
                Neighborhood = neighborhood,
                Complement = complement,
                City = city,
                State = state
            };

            //act
            var address = result.GetAddress();

            //assert
            address.ZipCode.Should().Be(zipCode);
            address.Street.Should().Be(street);
            address.Number.Should().Be(number);
            address.Neighborhood.Should().Be(neighborhood);
            address.Complement.Should().Be(complement);
            address.City.Should().Be(city);
            address.State.Should().Be(state);
        }
    }
}

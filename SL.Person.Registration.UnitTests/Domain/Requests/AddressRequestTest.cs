using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.Requests
{
    public class AddressRequestTest
    {
        [Theory]
        [InlineData(123456789, "Rua", "Numero", "bairro", "Complemento", "Cidade", "Estado")]
        public void Should_get_address(long zipCode, string street, string number, string neighborhood, string complement, string city, string state)
        {
            //arrange
            //act
            var result = Address.CreateInstance(zipCode, street, number, neighborhood, complement, city, state);

            //assert
            result.ZipCode.Should().Be(zipCode);
            result.Street.Should().Be(street);
            result.Number.Should().Be(number);
            result.Neighborhood.Should().Be(neighborhood);
            result.Complement.Should().Be(complement);
            result.City.Should().Be(city);
            result.State.Should().Be(state);
        }
    }
}

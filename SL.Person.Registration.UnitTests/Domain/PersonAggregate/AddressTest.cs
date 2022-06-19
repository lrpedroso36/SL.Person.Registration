using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate
{
    public class AddressTest
    {
        [Theory]
        [InlineData("123456789", "rua", "numero", "bairro", "complemento", "cidade", "estado")]
        public void Should_set_properties(string zipCode, string street, string number,
            string neighborhood, string complement, string city, string state)
        {
            //arrange
            //act
            var address = Address.CreateInstance(zipCode, street, number, neighborhood, complement, city, state);

            //assert
            address.ZipCode.Should().Be(zipCode);
            address.ZipCode.Should().BeOfType(typeof(string));

            address.Street.Should().Be(street);
            address.Street.Should().BeOfType(typeof(string));

            address.Number.Should().Be(number);
            address.Number.Should().BeOfType(typeof(string));

            address.Neighborhood.Should().Be(neighborhood);
            address.Neighborhood.Should().BeOfType(typeof(string));

            address.Complement.Should().Be(complement);
            address.Complement.Should().BeOfType(typeof(string));

            address.City.Should().Be(city);
            address.City.Should().BeOfType(typeof(string));

            address.State.Should().Be(state);
            address.State.Should().BeOfType(typeof(string));
        }

        [Theory]
        [InlineData("123456789", "rua", "numero", "bairro", "complemento", "cidade", "estado", true)]
        [InlineData("123456789", "rua", "numero", "bairro", "", "cidade", "estado", true)]
        [InlineData("", "rua", "numero", "bairro", "", "cidade", "estado", false)]
        [InlineData("123456789", "", "numero", "bairro", "complemento", "cidade", "estado", false)]
        [InlineData("123456789", "rua", "", "bairro", "complemento", "cidade", "estado", false)]
        [InlineData("123456789", "rua", "numero", "", "", "cidade", "estado", false)]
        [InlineData("123456789", "rua", "numero", "bairro", "", "", "estado", false)]
        [InlineData("123456789", "rua", "numero", "bairro", "", "cidade", "", false)]
        public void Should_validate(string zipCode, string street, string number,
            string neighborhood, string complement, string city, string state, bool isValid)
        {
            //arrange
            //act
            var address = Address.CreateInstance(zipCode, street, number, neighborhood, complement, city, state);

            //assert
            address.ZipCode.Should().Be(zipCode);
            address.ZipCode.Should().BeOfType(typeof(string));

            address.Street.Should().Be(street);
            address.Street.Should().BeOfType(typeof(string));

            address.Number.Should().Be(number);
            address.Number.Should().BeOfType(typeof(string));

            address.Neighborhood.Should().Be(neighborhood);
            address.Neighborhood.Should().BeOfType(typeof(string));

            address.Complement.Should().Be(complement);
            address.Complement.Should().BeOfType(typeof(string));

            address.City.Should().Be(city);
            address.City.Should().BeOfType(typeof(string));

            address.State.Should().Be(state);
            address.State.Should().BeOfType(typeof(string));

            address.IsValid().Should().Be(isValid);
        }
    }
}

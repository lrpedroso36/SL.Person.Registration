using FluentValidation.TestHelper;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Validations;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate.Validations
{
    public class AddressValidationTest
    {
        private readonly AddressValidation _addressValidation;

        public AddressValidationTest()
        {
            _addressValidation = new AddressValidation();
        }

        [Fact]
        public void Should_validation_have_errors_in_zip_code()
        {
            //arrange 
            var address = Address.CreateInstance(0, "rua", "number", "bairro", "complemento", "cidade", "estado");

            //act
            var result = _addressValidation.TestValidate(address);

            //assert
            result.ShouldHaveValidationErrorFor(address => address.ZipCode);
        }

        [Fact]
        public void Should_validation_not_have_errors()
        {
            //arrange 
            var address = Address.CreateInstance(123456789, "rua", "number", "bairro", "complemento", "cidade", "estado");

            //act
            var result = _addressValidation.TestValidate(address);

            //assert
            result.ShouldNotHaveValidationErrorFor(address => address.ZipCode);
            result.ShouldNotHaveValidationErrorFor(address => address.Street);
            result.ShouldNotHaveValidationErrorFor(address => address.Number);
            result.ShouldNotHaveValidationErrorFor(address => address.Neighborhood);
            result.ShouldNotHaveValidationErrorFor(address => address.City);
            result.ShouldNotHaveValidationErrorFor(address => address.State);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validation_have_errors_in_street(string street)
        {
            //arrange 
            var address = Address.CreateInstance(0, street, "number", "bairro", "complemento", "cidade", "estado");

            //act
            var result = _addressValidation.TestValidate(address);

            //assert
            result.ShouldHaveValidationErrorFor(address => address.Street);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validation_have_errors_in_number(string number)
        {
            //arrange 
            var address = Address.CreateInstance(0, "rua", number, "bairro", "complemento", "cidade", "estado");

            //act
            var result = _addressValidation.TestValidate(address);

            //assert
            result.ShouldHaveValidationErrorFor(address => address.Number);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validation_have_errors_in_neighborhood(string neighborhood)
        {
            //arrange 
            var address = Address.CreateInstance(0, "rua", "number", neighborhood, "complemento", "cidade", "estado");

            //act
            var result = _addressValidation.TestValidate(address);

            //assert
            result.ShouldHaveValidationErrorFor(address => address.Neighborhood);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validation_have_errors_in_city(string city)
        {
            //arrange 
            var address = Address.CreateInstance(0, "rua", "number", "bairro", "complemento", city, "estado");

            //act
            var result = _addressValidation.TestValidate(address);

            //assert
            result.ShouldHaveValidationErrorFor(address => address.City);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validation_have_errors_in_state(string state)
        {
            //arrange 
            var address = Address.CreateInstance(0, "rua", "number", "bairro", "complemento", "cidade", state);

            //act
            var result = _addressValidation.TestValidate(address);

            //assert
            result.ShouldHaveValidationErrorFor(address => address.State);
        }
    }
}

using FluentAssertions;
using FluentValidation.Results;
using SL.Person.Registration.Domain.External.Response;
using SL.Person.Registration.Domain.External.Response.Validations;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.External.Response.Validations
{
    public class AddressResponseInstanceValidationTest
    {
        [Fact]
        public void Should_validation_instance()
        {
            //arrange
            AddressResponse addressResponse = null;
            var validationFailure = new[] { new ValidationFailure("instance", "Endereço não encontrado.") };

            //act
            var validation = new AddressResponseInstanceValidation();
            var resultValidation = validation.Validate(addressResponse);

            //assert
            resultValidation.IsValid.Should().BeFalse();
            resultValidation.Errors.Should().BeEquivalentTo(validationFailure);
        }
    }
}

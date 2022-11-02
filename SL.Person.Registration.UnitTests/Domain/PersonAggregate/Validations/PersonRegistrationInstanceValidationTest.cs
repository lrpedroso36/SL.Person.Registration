using FluentAssertions;
using FluentValidation.Results;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Validations;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate.Validations
{
    public class PersonRegistrationInstanceValidationTest
    {
        [Fact]
        public void Should_validation_instance()
        {
            //arrange
            PersonRegistration person = null;
            var validationFailure = new[] { new ValidationFailure("instance", "Pessoa não encontrada.") };

            //act
            var validation = new PersonRegistrationInstanceValidation();
            var resultValidation = validation.Validate(person);

            //assert
            resultValidation.IsValid.Should().BeFalse();
            resultValidation.Errors.Should().BeEquivalentTo(validationFailure);
        }
    }
}

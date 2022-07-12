using FluentAssertions;
using FluentValidation.Results;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate.Validations;
using SL.Person.Registration.Domain.Resources;
using System.Collections.Generic;
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
            var validationFailure = new[] { new ValidationFailure("instance", DomainMessages.PersonRegistration_InstanceInvalid) };

            //act
            var validation = new PersonRegistrationInstanceValidation();
            var resultValidation = validation.Validate(person);

            //assert
            resultValidation.IsValid.Should().BeFalse();
            resultValidation.Errors.Should().BeEquivalentTo(validationFailure);
        }

        public static List<object[]> Data = new List<object[]>
        {
            new object[] { PersonType.Tarefeiro, DomainMessages.PersonRegistrationLabore_InstanceInvalid },
            new object[] { PersonType.Assistido, DomainMessages.PersonRegistrationWatched_InstanceInvalid },
            new object[] { PersonType.Palestrante, DomainMessages.PersonRegistrationSpeaker_InstanceInvalid },
            new object[] { PersonType.Entrevistador, DomainMessages.PersonRegistrationInterviewer_InstanceInvalid }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_validation_instance_by_type(PersonType personType, string message)
        {
            //arrange
            PersonRegistration person = null;
            var validationFailure = new[] { new ValidationFailure("instance", message) };

            //act
            var validation = new PersonRegistrationInstanceValidation(personType);
            var resultValidation = validation.Validate(person);

            //assert
            resultValidation.IsValid.Should().BeFalse();
            resultValidation.Errors.Should().BeEquivalentTo(validationFailure);
        }
    }
}

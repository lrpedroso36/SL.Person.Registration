using FluentAssertions;
using FluentValidation.Results;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate.Validations;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate.Validations
{
    public class PersonRegistrationValidationTest
    {
        [Fact]
        public void Should_validation_instance()
        {
            //arrange
            PersonRegistration person = null;
            var validationFailure = new[] { new ValidationFailure("instance", ResourceMessagesValidation.PersonRegistration_InstanceInvalid) };

            //act
            var validation = new PersonRegistrationValidation();
            var resultValidation = validation.Validate(person);

            //assert
            resultValidation.IsValid.Should().BeFalse();
            resultValidation.Errors.Should().BeEquivalentTo(validationFailure);
        }

        public static List<object[]> Data = new List<object[]>
        {
            new object[] { PersonType.Tarefeiro, ResourceMessagesValidation.PersonRegistrationLabore_InstanceInvalid },
            new object[] { PersonType.Assistido, ResourceMessagesValidation.PersonRegistrationWatched_InstanceInvalid },
            new object[] { PersonType.Palestrante, ResourceMessagesValidation.PersonRegistrationSpeaker_InstanceInvalid },
            new object[] { PersonType.Entrevistador, ResourceMessagesValidation.PersonRegistrationInterviewer_InstanceInvalid }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_validation_instance_by_type(PersonType personType, string message)
        {
            //arrange
            PersonRegistration person = null;
            var validationFailure = new[] { new ValidationFailure("instance", message) };

            //act
            var validation = new PersonRegistrationValidation(personType);
            var resultValidation = validation.Validate(person);

            //assert
            resultValidation.IsValid.Should().BeFalse();
            resultValidation.Errors.Should().BeEquivalentTo(validationFailure);
        }
    }
}

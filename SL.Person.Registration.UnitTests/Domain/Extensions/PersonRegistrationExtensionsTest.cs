using FluentAssertions;
using FluentValidation.Results;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate.Extensions;
using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.Extensions
{
    public class PersonRegistrationExtensionsTest
    {
        public static List<object[]> Data = new List<object[]>
        {
           new object[] { PersonType.Tarefeiro , ResourceMessagesValidation.PersonRegistrationLabore_InstanceInvalid },
           new object[] { PersonType.Assistido, ResourceMessagesValidation.PersonRegistrationWatched_InstanceInvalid },
           new object[] { PersonType.Palestrante, ResourceMessagesValidation.PersonRegistrationSpeaker_InstanceInvalid },
           new object[] { PersonType.Entrevistador, ResourceMessagesValidation.PersonRegistrationInterviewer_InstanceInvalid }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_validate_instance_type(PersonType personType, string messageValidate)
        {
            //arrange 
            var expected = new List<string> { messageValidate };
            PersonRegistration person = null;

            //act
            var result = person.ValidateInstanceByType<bool>(personType);

            //assert
            result.Errors.Should().BeEquivalentTo(expected);
            result.Data.Should().BeFalse();
            result.IsSuccess.Should().BeFalse();
            result.ErrorType.Should().Be(ErrorType.NotFoundData);
        }


        [Fact]
        public void Should_validate_instance()
        {
            //arrange
            var expected = new List<string> { ResourceMessagesValidation.PersonRegistration_InstanceInvalid };
            PersonRegistration person = null;

            //act
            var result = person.ValidateInstance<bool>();

            //assert
            result.Errors.Should().BeEquivalentTo(expected);
            result.Data.Should().BeFalse();
            result.IsSuccess.Should().BeFalse();
            result.ErrorType.Should().Be(ErrorType.NotFoundData);
        }
    }
}

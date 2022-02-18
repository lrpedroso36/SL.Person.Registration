using FluentAssertions;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Results.Enums;
using System;
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
            Action action = () => person.ValidateInstanceByType(personType);

            //assert
            action.Should().Throw<HttpRequestException>();
        }


        [Fact]
        public void Should_validate_instance()
        {
            //arrange
            var expected = new List<string> { ResourceMessagesValidation.PersonRegistration_InstanceInvalid };
            PersonRegistration person = null;

            //act
            Action action = () => person.ValidateInstance();

            //assert
            action.Should().Throw<HttpRequestException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validate_have_errors_name(string name)
        {
            //arrange
            var expected = new List<string> { ResourceMessagesValidation.PersonRegistrationValidation_Name };
            var person = PersonRegistration.CreateInstance(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, name, 123456789);

            //act
            Action action = () => person.Validate();
             
            //assert
            action.Should().Throw<HttpRequestException>();
        }

        [Fact]
        public void Should_validate_have_errors_document_number()
        {
            //arrange
            var expected = new List<string> { ResourceMessagesValidation.PersonRegistrationValidation_DocumentNumber };
            var person = PersonRegistration.CreateInstance(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 0);

            //act
            Action action = () => person.Validate();

            //assert
            action.Should().Throw<HttpRequestException>();
        }
    }
}

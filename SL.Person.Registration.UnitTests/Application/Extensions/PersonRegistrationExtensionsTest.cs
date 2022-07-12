using FluentAssertions;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Resources;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Extensions
{
    public class PersonRegistrationExtensionsTest
    {
        public static List<object[]> Data = new List<object[]>
        {
           new object[] { PersonType.Tarefeiro , DomainMessages.PersonRegistrationLabore_InstanceInvalid },
           new object[] { PersonType.Assistido, DomainMessages.PersonRegistrationWatched_InstanceInvalid },
           new object[] { PersonType.Palestrante, DomainMessages.PersonRegistrationSpeaker_InstanceInvalid },
           new object[] { PersonType.Entrevistador, DomainMessages.PersonRegistrationInterviewer_InstanceInvalid }
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
            action.Should().Throw<ApplicationRequestException>();
        }


        [Fact]
        public void Should_validate_instance()
        {
            //arrange
            var expected = new List<string> { DomainMessages.PersonRegistration_InstanceInvalid };
            PersonRegistration person = null;

            //act
            Action action = () => person.ValidateInstance();

            //assert
            action.Should().Throw<ApplicationRequestException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validate_have_errors_name(string name)
        {
            //arrange
            var expected = new List<string> { DomainMessages.PersonRegistrationValidation_Name };
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, name, 123456789);

            //act
            Action action = () => person.Validate();

            //assert
            action.Should().Throw<DomainException>();
        }

        [Fact]
        public void Should_validate_have_errors_document_number()
        {
            //arrange
            var expected = new List<string> { DomainMessages.PersonRegistrationValidation_DocumentNumber };
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 0);

            //act
            Action action = () => person.Validate();

            //assert
            action.Should().Throw<DomainException>();
        }
    }
}

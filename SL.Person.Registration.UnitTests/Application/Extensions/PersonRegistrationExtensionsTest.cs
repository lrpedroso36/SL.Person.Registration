using FluentAssertions;
using SL.Person.Registration.Application.Command.Person.Extensions;
using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Domain.PersonAggregate;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Extensions
{
    public class PersonRegistrationExtensionsTest
    {
        [Fact]
        public void Should_validate_instance()
        {
            //arrange
            var expected = new List<string> { "Pessoa não encontrada." };
            PersonRegistration person = null;

            //act
            Action action = () => person.ValidateIsNotFoundInstance();

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
            var expected = new List<string> { "Informe o Nome da pessoa." };
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido() }, name, 123456789);

            //act
            Action action = () => person.Validate();

            //assert
            action.Should().Throw<DomainException>();
        }

        [Fact]
        public void Should_validate_have_errors_document_number()
        {
            //arrange
            var expected = new List<string> { "Informe o Número do documento da pessoa." };
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido() }, "name", 0);

            //act
            Action action = () => person.Validate();

            //assert
            action.Should().Throw<DomainException>();
        }
    }
}

using FluentValidation.TestHelper;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate.Validations;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate.Validations
{
    public class PersonRegistrationValidationTest
    {
        private readonly PersonRegistrationValidation _personRegistrationValidation;

        public PersonRegistrationValidationTest()
        {
            _personRegistrationValidation = new PersonRegistrationValidation();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validation_have_errors_in_name(string name)
        {
            //arrange 
            var person = PersonRegistration.CreateInstance(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, name, 123456789);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldHaveValidationErrorFor(person => person.Name);
        }

        [Fact]
        public void Should_validation_not_have_errors_in_name()
        {
            //arrange 
            var person = PersonRegistration.CreateInstance(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 123456789);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldNotHaveValidationErrorFor(person => person.Name);
        }

        [Fact]
        public void Should_validation_have_errors_in_document_number()
        {
            //arrange 
            var person = PersonRegistration.CreateInstance(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 0);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldHaveValidationErrorFor(person => person.DocumentNumber);
        }

        [Fact]
        public void Should_validation_not_have_errors_in_document_number()
        {
            //arrange 
            var person = PersonRegistration.CreateInstance(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 1234567890);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldNotHaveValidationErrorFor(person => person.DocumentNumber);
        }
    }
}

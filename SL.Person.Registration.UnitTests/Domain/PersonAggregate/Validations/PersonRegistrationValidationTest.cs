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
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, name, 123456789);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldHaveValidationErrorFor(person => person.Name);
        }

        [Fact]
        public void Should_validation_have_errors_in_document_number()
        {
            //arrange 
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 0);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldHaveValidationErrorFor(person => person.DocumentNumber);
        }

        [Fact]
        public void Should_validation_not_have_errors_person()
        {
            //arrange 
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 123456789);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldNotHaveValidationErrorFor(person => person.Name);
            result.ShouldNotHaveValidationErrorFor(person => person.DocumentNumber);
        }

        [Fact]
        public void Should_validation_have_errors_in_ddd()
        {
            //arrange 
            var contact = Contact.CreateInstance(0, 123456789);
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 123456789);
            person.AddContact(contact);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldHaveValidationErrorFor(person => person.Contact.DDD);
        }

        [Fact]
        public void Should_validation_not_have_errors_in_contact()
        {
            //arrange 
            var contact = Contact.CreateInstance(11, 123456789);
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 123456789);
            person.AddContact(contact);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldNotHaveValidationErrorFor(person => person.Contact.DDD);
            result.ShouldNotHaveValidationErrorFor(person => person.Contact.PhoneNumber);

        }

        [Fact]
        public void Should_validation_have_errors_in_phoneNumber()
        {
            //arrange 
            var contact = Contact.CreateInstance(11, 0);
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 123456789);
            person.AddContact(contact);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldHaveValidationErrorFor(person => person.Contact.PhoneNumber);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validation_have_errors_in_zipCode(string zipCode)
        {
            //arrange 
            var address = Address.CreateInstance(zipCode, "rua", "numero", "bairro", "complemento", "cidade", "estado");
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 123456789);
            person.AddAdress(address);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldHaveValidationErrorFor(person => person.Address.ZipCode);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validation_have_errors_in_street(string street)
        {
            //arrange 
            var address = Address.CreateInstance("zipCode", street, "numero", "bairro", "complemento", "cidade", "estado");
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 123456789);
            person.AddAdress(address);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldHaveValidationErrorFor(person => person.Address.Street);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validation_have_errors_in_number(string number)
        {
            //arrange 
            var address = Address.CreateInstance("zipCode", "rua", number, "bairro", "complemento", "cidade", "estado");
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 123456789);
            person.AddAdress(address);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldHaveValidationErrorFor(person => person.Address.Number);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validation_have_errors_in_neighborhood(string neighborhood)
        {
            //arrange 
            var address = Address.CreateInstance("zipCode", "rua", "numero", neighborhood, "complemento", "cidade", "estado");
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 123456789);
            person.AddAdress(address);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldHaveValidationErrorFor(person => person.Address.Neighborhood);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validation_have_errors_in_city(string city)
        {
            //arrange 
            var address = Address.CreateInstance("zipCode", "rua", "numero", "bairro", "complemento", city, "estado");
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 123456789);
            person.AddAdress(address);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldHaveValidationErrorFor(person => person.Address.City);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validation_have_errors_in_state(string state)
        {
            //arrange 
            var address = Address.CreateInstance("zipCode", "rua", "numero", "bairro", "complemento", "cidade", state);
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 123456789);
            person.AddAdress(address);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldHaveValidationErrorFor(person => person.Address.State);
        }

        [Fact]
        public void Should_validation_not_have_errors_address()
        {
            //arrange 
            var address = Address.CreateInstance("cep", "rua", "numero", "bairro", "complemento", "cidade", "estado");
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "name", 123456789);
            person.AddAdress(address);

            //act
            var result = _personRegistrationValidation.TestValidate(person);

            //assert
            result.ShouldNotHaveValidationErrorFor(person => person.Address.ZipCode);
            result.ShouldNotHaveValidationErrorFor(person => person.Address.Street);
            result.ShouldNotHaveValidationErrorFor(person => person.Address.Number);
            result.ShouldNotHaveValidationErrorFor(person => person.Address.Neighborhood);
            result.ShouldNotHaveValidationErrorFor(person => person.Address.City);
            result.ShouldNotHaveValidationErrorFor(person => person.Address.State);
        }
    }
}

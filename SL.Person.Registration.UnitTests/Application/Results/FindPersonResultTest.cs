using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Results
{
    public class FindPersonResultTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { Builder<PersonRegistration>.CreateNew().Build() }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_converter_person_registration(PersonRegistration person)
        {
            //arrange
            //act
            var result = (FindPersonResult)person;

            var yearsOld = DateTime.Now.Year - person.BithDate.Value.Year;

            //assert
            result.Id.Should().Be(person._id.ToString());
            result.Types.Should().BeEquivalentTo(person.Types);
            result.Name.Should().Be(person.Name);
            result.Gender.Should().Be(person.Gender);
            result.YearsOld.Should().Be(yearsOld);
            result.BirthDate.Should().Be(person.BithDate.Value.ToString("yyyy-MM-dd"));
            result.DocumentNumber.Should().Be(person.DocumentNumber);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_convert_person_registration_with_contact(PersonRegistration person)
        {
            //arrange
            person.AddContact(Builder<Contact>.CreateNew().Build());

            var yearsOld = DateTime.Now.Year - person.BithDate.Value.Year;

            //act
            var result = (FindPersonResult)person;

            //assert
            result.Id.Should().Be(person._id.ToString());
            result.Types.Should().BeEquivalentTo(person.Types);
            result.Name.Should().Be(person.Name);
            result.Gender.Should().Be(person.Gender);
            result.YearsOld.Should().Be(yearsOld);
            result.BirthDate.Should().Be(person.BithDate.Value.ToString("yyyy-MM-dd"));
            result.DocumentNumber.Should().Be(person.DocumentNumber);
            result.DDD.Should().Be(person.Contact.DDD);
            result.PhoneNumber.Should().Be(person.Contact.PhoneNumber);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_convert_person_registration_with_address(PersonRegistration person)
        {
            //arrange
            person.AddAdress(Builder<Address>.CreateNew().Build());

            var yearsOld = DateTime.Now.Year - person.BithDate.Value.Year;

            //act
            var result = (FindPersonResult)person;

            //assert
            result.Id.Should().Be(person._id.ToString());
            result.Types.Should().BeEquivalentTo(person.Types);
            result.Name.Should().Be(person.Name);
            result.Gender.Should().Be(person.Gender);
            result.YearsOld.Should().Be(yearsOld);
            result.BirthDate.Should().Be(person.BithDate.Value.ToString("yyyy-MM-dd"));
            result.DocumentNumber.Should().Be(person.DocumentNumber);
            result.ZipCode.Should().Be(person.Address.ZipCode);
            result.Street.Should().Be(person.Address.Street);
            result.Number.Should().Be(person.Address.Number);
            result.Neighborhood.Should().Be(person.Address.Neighborhood);
            result.Complement.Should().Be(person.Address.Complement);
            result.City.Should().Be(person.Address.City);
            result.State.Should().Be(person.Address.State);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_convert_person_registration_with_address_and_contact(PersonRegistration person)
        {
            //arrange
            person.AddAdress(Builder<Address>.CreateNew().Build());
            person.AddContact(Builder<Contact>.CreateNew().Build());
            var yearsOld = DateTime.Now.Year - person.BithDate.Value.Year;

            //act
            var result = (FindPersonResult)person;

            //assert
            result.Id.Should().Be(person._id.ToString());
            result.Types.Should().BeEquivalentTo(person.Types);
            result.Name.Should().Be(person.Name);
            result.Gender.Should().Be(person.Gender);
            result.YearsOld.Should().Be(yearsOld);
            result.BirthDate.Should().Be(person.BithDate.Value.ToString("yyyy-MM-dd"));
            result.DocumentNumber.Should().Be(person.DocumentNumber);
            result.ZipCode.Should().Be(person.Address.ZipCode);
            result.Street.Should().Be(person.Address.Street);
            result.Number.Should().Be(person.Address.Number);
            result.Neighborhood.Should().Be(person.Address.Neighborhood);
            result.Complement.Should().Be(person.Address.Complement);
            result.City.Should().Be(person.Address.City);
            result.State.Should().Be(person.Address.State);
            result.DDD.Should().Be(person.Contact.DDD);
            result.PhoneNumber.Should().Be(person.Contact.PhoneNumber);
        }

        [Fact]
        public void Should_convert_person_registration_with_birth_date_null()
        {
            //arrange
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Tarefeiro }, "nome", 123456789);

            //act
            var result = (FindPersonResult)person;

            //assert
            result.BirthDate.Should().Be("0001-01-01");
            result.YearsOld.Should().Be(0);
        }
    }
}

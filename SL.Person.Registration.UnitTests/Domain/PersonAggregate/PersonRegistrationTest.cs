using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate
{
    public class PersonRegistrationTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { new List<PersonType> { PersonType.Assistido },
                "nome",
                GenderType.Masculino,
                33,
                1234567890,
                null,
                null
            },
            new object[]
            {
                new List<PersonType> { PersonType.Assistido },
                "nome",
                GenderType.Masculino,
                33,
                1234567890,
                Builder<Address>.CreateNew().Build(),
                null
            },
            new object[]
            {
                new List<PersonType> { PersonType.Assistido },
                "nome",
                GenderType.Masculino,
                33,
                1234567890,
                Builder<Address>.CreateNew().Build(),
                Builder<Contact>.CreateNew().Build()
             }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Shoud_set_properties(List<PersonType> types,
             string name,
             GenderType gender,
             int yeasOld,
             long documentNumber,
             Address address,
             Contact contact)
        {
            //arrange
            //act
            var person = PersonRegistration.CreateInstance(types, name, gender, yeasOld, documentNumber,
                address, contact);

            //assert
            person.Types.Should().BeEquivalentTo(types);

            person.Name.Should().Be(name);
            person.Name.Should().BeOfType(typeof(string));

            person.Gender.Should().Be(gender);

            person.YearsOld.Should().Be(yeasOld);
            person.YearsOld.Should().BeOfType(typeof(int));

            person.DocumentNumber.Should().Be(documentNumber);
            person.DocumentNumber.Should().BeOfType(typeof(long));

            person.Address.Should().BeEquivalentTo(address);

            person.Contact.Should().BeEquivalentTo(contact);
        }

        [Fact]
        public void Should_set_properties_short_instace()
        {
            //arrange
            var id = Guid.NewGuid();
            var types = new List<PersonType> { PersonType.Assistido };
            var name = "Nome";
            var documentNumber = 123456789L;

            //act
            var person = PersonRegistration.CreateInstance(id, types, name, documentNumber);

            //asserts
            person._id.Should().Be(id);
            person.Types.Should().BeEquivalentTo(types);
            person.Name.Should().Be(name);
            person.DocumentNumber.Should().Be(documentNumber);

            person.Gender.Should().Be(0);
            person.YearsOld.Should().Be(0);
            person.Address.Should().BeNull();
            person.Contact.Should().BeNull();
        }

        [Fact]
        public void Should_set_id_person_registration()
        {
            //arrage
            var id = Guid.NewGuid();
            var person = Builder<PersonRegistration>.CreateNew().Build();

            //act
            person.SetId(id);

            //assert
            person._id.Should().Be(id);
        }

        [Fact]
        public void Should_add_person_type()
        {
            //arrange
            var personType = PersonType.Palestrante;
            var person = Builder<PersonRegistration>.CreateNew().Build();

            //act
            person.AddPersonType(personType);

            //assert
            person.Types.Should().Contain(personType);
        }

        [Fact]
        public void Should_add_address()
        {
            //arrange
            var address = Builder<Address>.CreateNew().Build();
            var person = Builder<PersonRegistration>.CreateNew().Build();

            //act
            person.AddAdress(address);

            //assert
            person.Address.Should().BeEquivalentTo(address);
        }

        [Fact]
        public void Should_add_contact()
        {
            //arrange 
            var contact = Builder<Contact>.CreateNew().Build();
            var person = Builder<PersonRegistration>.CreateNew().Build();

            //act
            person.AddContact(contact);

            //assert
            person.Contact.Should().BeEquivalentTo(contact);
        }
    }
}

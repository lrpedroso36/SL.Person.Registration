using System;
using System.Collections.Generic;
using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate
{
    public class PersonRegistrationTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { new List<PersonType> { PersonType.Assistido },
                "nome",
                new DateTime(1988,04,29),
                33,
                1234567890,
                null,
                null,
                null
            },
            new object[]
            {
                new List<PersonType> { PersonType.Assistido },
                "nome",
                new DateTime(1988,04,29),
                33,
                1234567890,
                Builder<Address>.CreateNew().Build(),
                null,
                null
            },
            new object[]
            {
                new List<PersonType> { PersonType.Assistido },
                "nome",
                new DateTime(1988,04,29),
                33,
                1234567890,
                Builder<Address>.CreateNew().Build(),
                Builder<Contact>.CreateNew().Build(),
                null
            },
            new object[]
            {
                new List<PersonType> { PersonType.Assistido },
                "nome",
                new DateTime(1988,04,29),
                33,
                1234567890,
                Builder<Address>.CreateNew().Build(),
                Builder<Contact>.CreateNew().Build(),
                Builder<Authentication>.CreateNew().Build()
            }
        };

       [Theory]
       [MemberData(nameof(Data))]
       public void Shoud_set_properties(List<PersonType> types,
            string name,
            DateTime birthDate,
            int yeasOld,
            long documentNumber,
            Address address,
            Contact contact,
            Authentication authentication)
        {
            var person = PersonRegistration.CreateInstance(types, name, birthDate, yeasOld, documentNumber,
                address, contact, authentication);

            person.Types.Should().BeEquivalentTo(types);

            person.Name.Should().Be(name);
            person.Name.Should().BeOfType(typeof(string));

            person.BirthDate.Should().Be(birthDate);

            person.YearsOld.Should().Be(yeasOld);
            person.YearsOld.Should().BeOfType(typeof(int));

            person.DocumentNumber.Should().Be(documentNumber);
            person.DocumentNumber.Should().BeOfType(typeof(long));

            person.Address.Should().BeEquivalentTo(address);

            person.Contact.Should().BeEquivalentTo(contact);

            person.Authentication.Should().BeEquivalentTo(authentication);
        }
    }
}

using System.Collections.Generic;
using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Results;

namespace SL.Person.Registration.UnitTests.Domain.Results
{
    public class FindPersonResultTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { Builder<PersonRegistration>.CreateNew().Build(), Builder<FindPersonResult>.CreateNew().Build() }
        };

        public void Should_converter_person_registration(PersonRegistration person, FindPersonResult personResult)
        {
            var result = (FindPersonResult)person;

            result.Types.Should().BeEquivalentTo(person.Types);
            result.Name.Should().Be(person.Name);
            result.Gender.Should().Be(person.Gender);
            result.YearsOld.Should().Be(person.YearsOld);
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
    }
}

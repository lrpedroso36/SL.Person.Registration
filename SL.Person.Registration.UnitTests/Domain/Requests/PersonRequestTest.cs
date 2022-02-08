using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Domain.Requests;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.Requests
{
    public class PersonRequestTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { Builder<PersonRequest>.CreateNew().Build() }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_get_person(PersonRequest personRequest)
        {
            var person = personRequest.GetPersonRegistration();

            person.Types.Should().BeEquivalentTo(personRequest.Types);
            person.Name.Should().Be(personRequest.Name);
            person.Gender.Should().Be(personRequest.Gender);
            person.YearsOld.Should().Be(personRequest.YearsOld);
            person.DocumentNumber.Should().Be(personRequest.DocumentNumber);

            person.Address.Should().NotBeNull();
            person.Address.ZipCode.Should().Be(personRequest.ZipCode);
            person.Address.Street.Should().Be(personRequest.Street);
            person.Address.Number.Should().Be(personRequest.Number);
            person.Address.Neighborhood.Should().Be(personRequest.Neighborhood);
            person.Address.Complement.Should().Be(personRequest.Complement);
            person.Address.City.Should().Be(personRequest.City);
            person.Address.State.Should().Be(personRequest.State);

            person.Contact.Should().NotBeNull();
            person.Contact.DDD.Should().Be(personRequest.DDD);
            person.Contact.PhoneNumber.Should().Be(personRequest.PhoneNumber);
        }
    }
}

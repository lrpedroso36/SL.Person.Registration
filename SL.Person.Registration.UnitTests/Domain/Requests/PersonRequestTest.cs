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
            //arrange
            //act
            var person = personRequest.GetPersonRegistration();

            //assert
            person.Types.Should().BeEquivalentTo(personRequest.Types);
            person.Name.Should().Be(personRequest.Name);
            person.Gender.Should().Be(personRequest.Gender);
            person.YearsOld.Should().Be(personRequest.YearsOld);
            person.DocumentNumber.Should().Be(personRequest.DocumentNumber);
        }
    }
}

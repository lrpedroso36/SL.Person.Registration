using FluentAssertions;
using SL.Person.Registration.Application.Query.FindPeople;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query
{
    public class FindPersonByNameQueryTest
    {
        [Fact]
        public void Should_set_properties()
        {
            //arrange
            var name = "name";
            var documentNumber = 123456789;
            var personType = Guid.NewGuid();

            //act
            var query = new FindPeopleQuery(name, documentNumber, personType);

            //assert
            query.Name.Should().Be(name);
            query.PersonTypeId.Should().Be(personType);
            query.DocumentNumber.Should().Be(documentNumber);
        }
    }
}

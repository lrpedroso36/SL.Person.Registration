using FluentAssertions;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query
{
    public class FindPersonByNameQueryTest
    {
        [Theory]
        [InlineData("nome", PersonType.Palestrante)]
        [InlineData("nome", null)]

        public void Should_set_properties(string parameter, PersonType? personType)
        {
            //arrange
            //act
            var query = new FindPeopleQuery(parameter, personType);

            //assert
            query.Parameter.Should().Be(parameter);
            query.PersonType.Should().Be(personType);
        }
    }
}

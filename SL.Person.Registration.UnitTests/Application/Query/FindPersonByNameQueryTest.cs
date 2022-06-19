using FluentAssertions;
using SL.Person.Registration.Application.Query;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query
{
    public class FindPersonByNameQueryTest
    {
        [Theory]
        [InlineData("nome")]
        public void Should_set_properties(string parameter)
        {
            //arrange
            //act
            var query = new FindPeopleQuery(parameter);

            //assert
            query.Parameter.Should().Be(parameter);
        }
    }
}

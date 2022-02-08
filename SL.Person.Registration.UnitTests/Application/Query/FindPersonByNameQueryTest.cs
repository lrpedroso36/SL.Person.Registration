using FluentAssertions;
using SL.Person.Registration.Application.Query;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query
{
    public class FindPersonByNameQueryTest
    {
        [Theory]
        [InlineData("nome")]
        public void Should_set_properties(string name)
        {
            var query = new FindPersonByNameQuery(name);
            query.Name.Should().Be(name);
        }
    }
}

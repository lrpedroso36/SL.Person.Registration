using FluentAssertions;
using SL.Person.Registration.Application.Query;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query
{
    public class FindPersonByContactNumberQueryTest
    {
        [Theory]
        [InlineData(11, 123456789)]
        public void Should_set_properties(int ddd, long phoneNumber)
        {
            var query = new FindPersonByContactNumberQuery(ddd, phoneNumber);
            query.Ddd.Should().Be(ddd);
            query.PhoneNumber.Should().Be(phoneNumber);
        }
    }
}

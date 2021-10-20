using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate
{
    public class AuthenticationTest
    {
        [Theory]
        [InlineData("senha")]
        public void Should_set_properties(string passwaord)
        {
            var authentication = Authentication.CreateInstance(passwaord);
            authentication.Password.Should().Be(passwaord);
            authentication.Password.Should().BeOfType(typeof(string));
        }
    }
}

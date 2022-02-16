using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.Requests
{
    public class ContactRequestTest
    {
        [Theory]
        [InlineData(11, 987654321)]
        public void Should_get_contact(int ddd, long phoneNumber)
        {
            //arrange
            //act
            var result = Contact.CreateInstance(ddd, phoneNumber);

            //assert
            result.DDD.Should().Be(ddd);
            result.PhoneNumber.Should().Be(phoneNumber);
        }
    }
}

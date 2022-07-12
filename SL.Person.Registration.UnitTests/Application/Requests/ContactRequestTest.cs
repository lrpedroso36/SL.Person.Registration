using FluentAssertions;
using SL.Person.Registration.Application.Requests;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Requests
{
    public class ContactRequestTest
    {
        [Theory]
        [InlineData(11, 987654321)]
        public void Should_get_contact(int ddd, long phoneNumber)
        {
            //arrange
            var result = new ContactRequest() { DDD = ddd, PhoneNumber = phoneNumber };

            //act
            var contact = result.GetContact();

            //assert
            contact.DDD.Should().Be(ddd);
            contact.PhoneNumber.Should().Be(phoneNumber);
        }
    }
}

using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate
{
    public class ContactTest
    {
        [Theory]
        [InlineData(11, 91234567890)]
        public void Should_set_properties(int ddd, long phoneNumber)
        {
            //arrange
            //act
            var contact = Contact.CreateInstance(ddd, phoneNumber);

            //assert
            contact.DDD.Should().Be(ddd);
            contact.DDD.Should().BeOfType(typeof(int));

            contact.PhoneNumber.Should().Be(phoneNumber);
            contact.PhoneNumber.Should().BeOfType(typeof(long));
        }

        [Theory]
        [InlineData(0,0, false)]
        [InlineData(11, 0, false)]
        [InlineData(0, 123456789, false)]
        [InlineData(11,1234567890, true)]
        public void Shoud_validate(int ddd, long phoneNumber, bool isValid)
        {
            //arrange
            //act
            var contact = Contact.CreateInstance(ddd, phoneNumber);

            //assert
            contact.DDD.Should().Be(ddd);
            contact.DDD.Should().BeOfType(typeof(int));

            contact.PhoneNumber.Should().Be(phoneNumber);
            contact.PhoneNumber.Should().BeOfType(typeof(long));

            contact.IsValid().Should().Be(isValid);
        }
    }
}

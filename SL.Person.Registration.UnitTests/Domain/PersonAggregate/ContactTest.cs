using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate
{
    public class ContactTest
    {
        [Theory]
        [InlineData("91234567890")]
        public void Should_set_properties(string number)
        {
            //arrange
            //act
            var contact = Contact.CreateInstance(number);

            //assert
            contact.Number.Should().Be(number);
            contact.Number.Should().BeOfType(typeof(string));
        }
    }
}

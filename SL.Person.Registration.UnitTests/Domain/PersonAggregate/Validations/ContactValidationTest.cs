using FluentValidation.TestHelper;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Validations;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate.Validations
{
    public class ContactValidationTest
    {
        private readonly ContactValidation _contactValidation;

        public ContactValidationTest()
        {
            _contactValidation = new ContactValidation();
        }

        [Fact]
        public void Should_validation_not_have_errors()
        {
            //arrange 
            var contact = Contact.CreateInstance(11, "123456789");

            //act
            var result = _contactValidation.TestValidate(contact);

            //assert
            result.ShouldNotHaveValidationErrorFor(contact => contact.DDD);
            result.ShouldNotHaveValidationErrorFor(contact => contact.PhoneNumber);
        }

        [Fact]
        public void Should_validation_have_errors_in_ddd()
        {
            //arrange 
            var address = Contact.CreateInstance(0, "123456789");

            //act
            var result = _contactValidation.TestValidate(address);

            //assert
            result.ShouldHaveValidationErrorFor(contact => contact.DDD);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validation_have_errors_in_phone_number(string phoneNumber)
        {
            //arrange 
            var address = Contact.CreateInstance(11, phoneNumber);

            //act
            var result = _contactValidation.TestValidate(address);

            //assert
            result.ShouldHaveValidationErrorFor(contact => contact.PhoneNumber);
        }
    }
}

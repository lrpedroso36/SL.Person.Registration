using FluentAssertions;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Extensions;
using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.Extensions
{
    public class ContactExtensionsTest
    {
        [Fact]
        public void Should_validate_have_errors_ddd()
        {
            //arrange
            var expected = new List<string> { ResourceMessagesValidation.ContactValidation_DDD };
            var contact = Contact.CreateInstance(0, 123456789);

            //act
            var result = contact.Validate();

            //assert
            result.Errors.Should().BeEquivalentTo(expected);
            result.IsSuccess.Should().BeFalse();
            result.ErrorType.Should().Be(ErrorType.EntitiesProperty);
        }

        [Fact]
        public void Should_validate_have_errors_phone_number()
        {
            //arrange
            var expected = new List<string> { ResourceMessagesValidation.ContactValidation_PhoneNumber };
            var contact = Contact.CreateInstance(11, 0);

            //act
            var result = contact.Validate();

            //assert
            result.Errors.Should().BeEquivalentTo(expected);
            result.IsSuccess.Should().BeFalse();
            result.ErrorType.Should().Be(ErrorType.EntitiesProperty);
        }
    }
}

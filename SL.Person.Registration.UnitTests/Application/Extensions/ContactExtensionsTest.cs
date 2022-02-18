using FluentAssertions;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.PersonAggregate;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Extensions
{
    public class ContactExtensionsTest
    {
        [Fact]
        public void Should_validate_have_errors_ddd()
        {
            //arrange
            var contact = Contact.CreateInstance(0, 123456789);

            //act
            Action action = () => contact.Validate();

            //assert
            action.Should().Throw<ApplicationRequestException>();
        }

        [Fact]
        public void Should_validate_have_errors_phone_number()
        {
            //arrange
            var contact = Contact.CreateInstance(11, 0);

            //act
            Action action = () => contact.Validate();

            //assert
            action.Should().Throw<ApplicationRequestException>();
        }
    }
}

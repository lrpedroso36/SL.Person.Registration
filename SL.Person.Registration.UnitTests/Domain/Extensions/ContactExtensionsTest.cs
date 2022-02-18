using FluentAssertions;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Results.Enums;
using System;
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
            var contact = Contact.CreateInstance(0, 123456789);

            //act
            Action action = () => contact.Validate();

            //assert
            action.Should().Throw<HttpRequestException>();
        }

        [Fact]
        public void Should_validate_have_errors_phone_number()
        {
            //arrange
            var contact = Contact.CreateInstance(11, 0);

            //act
            Action action = () => contact.Validate();

            //assert
            action.Should().Throw<HttpRequestException>();
        }
    }
}

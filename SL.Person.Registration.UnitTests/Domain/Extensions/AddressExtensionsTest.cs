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
    public class AddressExtensionsTest
    {
        [Fact]
        public void Should_validate_have_errors_zip_code()
        {
            //arrange
            var expected = new List<string> { ResourceMessagesValidation.AddressValidation_ZipCode };
            var address = Address.CreateInstance(0, "rua", "number", "bairro", "complemento", "cidade", "estado");

            //act
            Action action = () => address.Validate();

            //assert
            action.Should().Throw<HttpRequestException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validate_have_errors_street(string street)
        {
            //arrange
            var expected = new List<string> { ResourceMessagesValidation.AddressValidation_Street };
            var address = Address.CreateInstance(1, street, "number", "bairro", "complemento", "cidade", "estado");

            //act
            Action result = () => address.Validate();

            //assert
            result.Should().Throw<HttpRequestException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validate_have_errors_number(string number)
        {
            //arrange
            var expected = new List<string> { ResourceMessagesValidation.AddressValidation_Number };
            var address = Address.CreateInstance(1, "rua", number, "bairro", "complemento", "cidade", "estado");

            //act
            Action result = () => address.Validate();

            //assert
            result.Should().Throw<HttpRequestException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validate_have_errors_neighborhood(string neighborhood)
        {
            //arrange
            var expected = new List<string> { ResourceMessagesValidation.AddressValidation_Neighborhood };
            var address = Address.CreateInstance(1, "rua", "number", neighborhood, "complemento", "cidade", "estado");

            //act
            Action result = () => address.Validate();

            //assert
            result.Should().Throw<HttpRequestException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validate_have_errors_city(string city)
        {
            //arrange
            var expected = new List<string> { ResourceMessagesValidation.AddressValidation_City };
            var address = Address.CreateInstance(1, "rua", "number", "bairro", "complemento", city, "estado");

            //act
            Action result = () => address.Validate();

            //assert
            result.Should().Throw<HttpRequestException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_validate_have_errors_state(string state)
        {
            //arrange
            var expected = new List<string> { ResourceMessagesValidation.AddressValidation_State };
            var address = Address.CreateInstance(1, "rua", "number", "bairro", "complemento", "cidade", state);

            //act
            Action result = () => address.Validate();

            //assert
            result.Should().Throw<HttpRequestException>();
        }
    }
}
